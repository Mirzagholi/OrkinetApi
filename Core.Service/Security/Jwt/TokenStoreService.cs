using Core.Common.Settings;
using Core.DataContract;
using Core.Models.Model.Security;
using Core.Models.Parameter.Security.Token;
using Core.ServiceContract.Security.Jwt;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Security.Jwt
{
    public class TokenStoreService : ITokenStoreService
    {
        private readonly IRepository _repository;
        private readonly ISecurityService _securityService;
        private readonly IOptionsSnapshot<SiteSettings> _jwtConfig;
        private readonly ITokenFactoryService _tokenFactoryService;

        public TokenStoreService(
            IRepository repository,
            ISecurityService securityService,
            IOptionsSnapshot<SiteSettings> jwtConfig,
            ITokenFactoryService tokenFactoryService)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _securityService = securityService ?? throw new ArgumentNullException(nameof(securityService));

            _jwtConfig = jwtConfig ?? throw new ArgumentNullException(nameof(jwtConfig));

            _tokenFactoryService = tokenFactoryService ?? throw new ArgumentNullException(nameof(tokenFactoryService));
        }

        public async Task AddUserTokenAsync(UserToken userToken)
        {
            if (!_jwtConfig.Value.BearerTokens.AllowMultipleLoginsFromTheSameUser)
            {
                await InvalidateUserTokensAsync(userToken.UserId);
            }
            await DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshTokenIdHashSource);

            await _repository.Sp_AddUserToken(userToken);
        }

        public async Task AddUserTokenAsync(User user, string refreshTokenSerial, string accessToken, string refreshTokenSourceSerial)
        {
            var now = DateTime.Now;
            var token = new UserToken
            {
                UserId = user.Id,
                // Refresh token handles should be treated as secrets and should be stored hashed
                RefreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial),
                RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSourceSerial) ?
                                           null : _securityService.GetSha256Hash(refreshTokenSourceSerial),
                AccessTokenHash = _securityService.GetSha256Hash(accessToken),
                RefreshTokenExpiresDateTime = now.AddMinutes(_jwtConfig.Value.BearerTokens.RefreshTokenExpirationMinutes),
                AccessTokenExpiresDateTime = now.AddMinutes(_jwtConfig.Value.BearerTokens.AccessTokenExpirationMinutes)
            };
            await AddUserTokenAsync(token);
        }

        public async Task DeleteExpiredTokensAsync()
        {
            await _repository.Sp_DeleteExpiredUserToken();
        }

        public async Task DeleteTokenAsync(string refreshTokenValue)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenValue)) return;

            var refreshTokenSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
            if (string.IsNullOrWhiteSpace(refreshTokenSerial)) return;

            var refreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial);
            await _repository.Sp_DeleteUserToken(new DeleteUserTokenParam() { RefreshTokenIdHash = refreshTokenIdHash });
        }

        public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource)) return;

            await _repository.Sp_DeleteUserTokensWithSameRefreshTokenSource(
                new DeleteUserTokensWithSameRefreshTokenSourceParam() { RefreshTokenIdHashSource = refreshTokenIdHashSource });
        }

        public async Task RevokeUserBearerTokensAsync(string userIdValue, string refreshTokenValue)
        {
            if (!string.IsNullOrWhiteSpace(userIdValue) && int.TryParse(userIdValue, out int userId))
            {
                if (_jwtConfig.Value.BearerTokens.AllowSignoutAllUserActiveClients)
                {
                    await InvalidateUserTokensAsync(userId);
                }
            }

            if (!string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                var refreshTokenSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
                if (!string.IsNullOrWhiteSpace(refreshTokenSerial))
                {
                    var refreshTokenIdHashSource = _securityService.GetSha256Hash(refreshTokenSerial);
                    await DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
                }
            }

            await DeleteExpiredTokensAsync();
        }

        public async Task<UserToken> FindTokenAsync(string refreshTokenValue)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenValue))
            {
                return await Task.FromResult<UserToken>(null);
            }

            var refreshTokenSerial = _tokenFactoryService.GetRefreshTokenSerial(refreshTokenValue);
            if (string.IsNullOrWhiteSpace(refreshTokenSerial))
            {
                return await Task.FromResult<UserToken>(null);
            }

            var refreshTokenIdHash = _securityService.GetSha256Hash(refreshTokenSerial);
            return await _repository.Sp_FindUserToken(new FindUserTokenParam { RefreshTokenIdHash = refreshTokenIdHash });
        }

        public async Task InvalidateUserTokensAsync(int userId)
        {
            await _repository.Sp_DeleteUserTokenByUserId(new DeleteUserTokenByUserIdParam { UserId = userId });
        }

        public async Task<bool> IsValidTokenAsync(string accessToken, int userId)
        {
            var accessTokenHash = _securityService.GetSha256Hash(accessToken);
            var userToken = await _repository.Sp_IsValidUserToken(
                new IsValidUserTokenParam 
                { 
                    AccessTokenHash = accessTokenHash,
                    UserId = userId
                });
            return userToken?.AccessTokenExpiresDateTime >= DateTime.Now;
        }
    }
}