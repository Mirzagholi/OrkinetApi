using Core.Common.Settings;
using Core.Models.Model.Security;
using Core.ServiceContract.Security;
using Core.ServiceContract.Security.Jwt;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Security.Jwt
{
    public class TokenFactoryService : ITokenFactoryService
    {
        private readonly ISecurityService _securityService;
        private readonly IOptionsSnapshot<SiteSettings> _jwtConfig;
        private readonly IRoleSrv _roleSrv;
        private readonly IUserRoleSrv _userRoleSrv;

        public TokenFactoryService(
            ISecurityService securityService,
            IRoleSrv roleSrv,
            IUserRoleSrv userRoleSrv,
            IOptionsSnapshot<SiteSettings> jwtConfig)
        {
            _securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));

            _roleSrv = roleSrv ?? throw new ArgumentNullException(nameof(roleSrv));

            _userRoleSrv = userRoleSrv ?? throw new ArgumentNullException(nameof(userRoleSrv));

            _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));
        }

        public async Task<UserTokenData> CreateJwtTokensAsync(User user)
        {
            var (accessToken, claims) = await createAccessTokenAsync(user);
            var (refreshTokenValue, refreshTokenSerial) = createRefreshToken();
            return new UserTokenData
            {
                AccessToken = accessToken,
                RefreshToken = refreshTokenValue,
                RefreshTokenSerial = refreshTokenSerial,
                Claims = claims
            };
        }

        private (string RefreshTokenValue, string RefreshTokenSerial) createRefreshToken()
        {
            var refreshTokenSerial = _securityService.CreateCryptographicallySecureGuid().ToString().Replace("-", "");

            var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, _securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, _jwtConfig.Value.BearerTokens.Issuer, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _jwtConfig.Value.BearerTokens.Issuer),
                // for invalidation
                new Claim(ClaimTypes.SerialNumber, refreshTokenSerial, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.BearerTokens.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Value.BearerTokens.Issuer,
                audience: _jwtConfig.Value.BearerTokens.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwtConfig.Value.BearerTokens.RefreshTokenExpirationMinutes),
                signingCredentials: creds);
            var refreshTokenValue = new JwtSecurityTokenHandler().WriteToken(token);
            return (refreshTokenValue, refreshTokenSerial);
        }

        public string GetRefreshTokenSerial(string refreshTokenValue)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return null;
            }

            ClaimsPrincipal decodedRefreshTokenPrincipal = null;
            decodedRefreshTokenPrincipal = new JwtSecurityTokenHandler().ValidateToken(
                refreshTokenValue,
                new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.BearerTokens.Key)),
                    ValidateIssuerSigningKey = true, // verify signature to avoid tampering
                        ValidateLifetime = true, // validate the expiration
                        ClockSkew = TimeSpan.Zero // tolerance for the expiration date
                    },
                out _
            );

            return decodedRefreshTokenPrincipal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.SerialNumber)?.Value;
        }

        private async Task<(string AccessToken, IEnumerable<Claim> Claims)> createAccessTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, _securityService.CreateCryptographicallySecureGuid().ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, _jwtConfig.Value.BearerTokens.Issuer, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _jwtConfig.Value.BearerTokens.Issuer),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                new Claim(ClaimTypes.Name, user.Username, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                new Claim("DisplayName", user.DisplayName, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                new Claim("ProviderName", string.IsNullOrEmpty(user.ProviderName) ? string.Empty : user.ProviderName, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // to invalidate the cookie
                new Claim(ClaimTypes.SerialNumber, user.SerialNumber.ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                // custom data
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer),
                new Claim("ProviderId", user.ProviderId.ToString(), ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer)
            };

            // add roles
            var roles = await _userRoleSrv.FindUserRolesAsync(user.Id);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name, ClaimValueTypes.String, _jwtConfig.Value.BearerTokens.Issuer));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Value.BearerTokens.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var now = DateTime.Now;
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Value.BearerTokens.Issuer,
                audience: _jwtConfig.Value.BearerTokens.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_jwtConfig.Value.BearerTokens.AccessTokenExpirationMinutes),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler().WriteToken(token), claims);
        }
    }
}