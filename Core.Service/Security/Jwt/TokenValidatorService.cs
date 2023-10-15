using Core.ServiceContract.Security;
using Core.ServiceContract.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Service.Security.Jwt
{
    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly IUserSrv _userSrv;
        private readonly ITokenStoreService _tokenStoreService;

        public TokenValidatorService(IUserSrv userSrv, ITokenStoreService tokenStoreService)
        {
            _userSrv = userSrv ?? throw new ArgumentNullException(nameof(userSrv));

            _tokenStoreService = tokenStoreService ?? throw new ArgumentNullException(nameof(tokenStoreService));
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            var claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            var serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
            if (serialNumberClaim == null)
            {
                context.Fail("This is not our issued token. It has no serial.");
                return;
            }

            var userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }

            var user = await _userSrv.FindUserByIdAsync(userId);
            if (user == null || user.SerialNumber.ToString() != serialNumberClaim.Value || !user.IsActive)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("This token is expired. Please login again.");
            }

            if (!(context.SecurityToken is JwtSecurityToken accessToken) || string.IsNullOrWhiteSpace(accessToken.RawData) ||
                !await _tokenStoreService.IsValidTokenAsync(accessToken.RawData, userId))
            {
                context.Fail("This token is not in our database.");
                return;
            }

            await _userSrv.UpdateUserLastActivityAsync(userId);
        }
    }
}