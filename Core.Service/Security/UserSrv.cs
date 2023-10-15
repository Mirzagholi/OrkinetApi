using System.Threading.Tasks;
using Core.Common.Extensions;
using Core.Common.Helpers;
using Core.DataContract;
using Core.ServiceContract.Security;
using Core.Common.ShareModels;
using Core.Common.ShareContract;
using Core.ServiceContract.Common;
using System;
using Core.Models.Request.Common.Sms;
using Core.Models.ViewModel.Security.User;
using Core.Models.Parameter.Security.User;
using Core.ServiceContract.Security.Jwt;
using Core.Models.Model.Security;
using Core.Models.Request.Security.User;

namespace Core.Service.Security
{
    public class UserSrv : IUserSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;
        private readonly ISmsSrv _smsSrv;
        private readonly ITokenFactoryService _tokenFactoryService;
        private readonly ITokenStoreService _tokenStoreService;
        private readonly IAntiForgeryCookieService _antiforgery;

        #endregion Property

        #region Constructor


        public UserSrv(
            IRepository repository,
            IServiceResultHelper serviceResultHelper,
            ISmsSrv smsSrv,
            ITokenFactoryService tokenFactoryService,
            ITokenStoreService tokenStoreService,
            IAntiForgeryCookieService antiforgery)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

            _serviceResultHelper = serviceResultHelper ?? throw new ArgumentNullException(nameof(serviceResultHelper));

            _smsSrv = smsSrv ?? throw new ArgumentNullException(nameof(smsSrv));

            _tokenFactoryService = tokenFactoryService ?? throw new ArgumentNullException(nameof(tokenFactoryService));

            _tokenStoreService = tokenStoreService ?? throw new ArgumentNullException(nameof(tokenStoreService));

            _antiforgery = antiforgery ?? throw new ArgumentNullException(nameof(antiforgery));
        }

        #endregion Constructor

        #region Methods

        public async Task<FindUserByIdVm> FindUserByIdAsync(int id)
        {
            return
                await _repository.Sp_FindUserById(new FindUserByIdParam() { Id = id });
        }

        public async Task UpdateUserLastActivityAsync(int id)
        {
            await _repository.Sp_UpdateUserLastActivity(new UpdateUserLastActivityParam() { Id = id });
        }

        public async Task<GetUserInfoVm> GetUserInfoAsync()
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            return
                await _repository.Sp_GetUserInfo(new GetUserInfoParam() { Id = userId });
        }

        public async Task<ServiceResult> LoginOrRegisterAsync(LoginOrRegisterRequest request)
        {
            var response = await _repository.Sp_LoginOrRegister(
                new LoginOrRegisterParam()
                {
                    MobileNumber = request.MobileNumber
                });

            if (!response.ExistUser)
            {
                var smsResponse = await SendUserConfirmCodeAsync(new UserConfirmCodeRequest { Username = request.MobileNumber });
                response.Expiration = smsResponse.Expiration;
            }

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> AuthenticateAsync(AuthenticateRequest request)
        {
            var response = await _repository.Sp_Authentication(
                new AuthenticateParam()
                {
                    Username = request.Username,
                    Password = AppHelper.GetMD5HashData(request.Password)
                });

            var tokenResponse = new UserTokenResponse();
            if (response != null)
            {
                var userResponse = await FindUserByIdAsync(response.Id);
                var user = new User
                {
                    Id = userResponse.Id,
                    ProviderId = userResponse.ProviderId,
                    Username = userResponse.Username,
                    DisplayName = userResponse.DisplayName,
                    ProviderName = userResponse.ProviderName,
                    LastLoggedIn = userResponse.LastLoggedIn,
                    SerialNumber = userResponse.SerialNumber
                };
                var token = await _tokenFactoryService.CreateJwtTokensAsync(user);
                await _tokenStoreService.AddUserTokenAsync(user, token.RefreshTokenSerial, token.AccessToken, null);
                //antiforgery
                _antiforgery.RegenerateAntiForgeryCookies(token.Claims);

                tokenResponse.access_token = token.AccessToken;
                tokenResponse.refresh_token = token.RefreshToken;
            }
            return _serviceResultHelper.Response(tokenResponse);
        }

        public async Task<ServiceResult> UserConfirmCodeAsync(UserConfirmCodeRequest request)
        {
            var response = await SendUserConfirmCodeAsync(new UserConfirmCodeRequest { Username = request.Username });
            return _serviceResultHelper.Response(response);
        }

        private async Task<UserConfirmCodeVm> SendUserConfirmCodeAsync(UserConfirmCodeRequest request)
        {
            var confirmCode = AppHelper.GenerateRandomNo4digits();
            var response = await _repository.Sp_UserConfirmCode(new UserConfirmCodeParam()
            {
                Username = request.Username,
                ConfirmCode = confirmCode

            });
            if (!response.IsSmsSended)
                await _smsSrv.SendConfirmationSmsAsync(new SendConfirmationSmsRequest() { MobileNumber = request.Username.Trim(), ConfirmCode = confirmCode.ToString() });
            return response;
        }

        public async Task<ServiceResult> UserActivationAsync(UserActivationRequest request)
        {
            var response = await _repository.Sp_UserActivation(
                new UserActivationParam()
                {
                    Username = request.Username,
                    ConfirmCode = request.ConfirmCode

                });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var response = await _repository.Sp_ResetPassword
            (new ResetPasswordParam()
            {
                Username = request.Username,
                ConfirmCode = request.ConfirmCode,
                Password = AppHelper.GetMD5HashData(request.Password)
            });
            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> SetPasswordAsync(SetPasswordRequest request)
        {
            var response = await _repository.Sp_SetPassword
            (new SetPasswordParam()
            {
                Username = request.Username,
                Password = AppHelper.GetMD5HashData(request.Password)
            });

            var tokenResponse = new UserTokenResponse();
            if (response != null)
            {
                var userResponse = await FindUserByIdAsync(response.Id);
                var user = new User
                {
                    Id = userResponse.Id,
                    ProviderId = userResponse.ProviderId,
                    Username = userResponse.Username,
                    DisplayName = userResponse.DisplayName,
                    ProviderName = userResponse.ProviderName,
                    LastLoggedIn = userResponse.LastLoggedIn,
                    SerialNumber = userResponse.SerialNumber
                };
                var token = await _tokenFactoryService.CreateJwtTokensAsync(user);
                await _tokenStoreService.AddUserTokenAsync(user, token.RefreshTokenSerial, token.AccessToken, null);
                //antiforgery
                _antiforgery.RegenerateAntiForgeryCookies(token.Claims);

                tokenResponse.access_token = token.AccessToken;
                tokenResponse.refresh_token = token.RefreshToken;
            }

            return _serviceResultHelper.Response(tokenResponse);
        }

        public async Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;
            var response = await _repository.Sp_UpdateUser(new UpdateUserParam()
            {
                Id = userId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                GenderTypeId = request.GenderTypeId,
                Avatar = string.Empty,
                Email = request.Email
            });

            return _serviceResultHelper.Response(response);
        }

        public async Task<ServiceResult> LogOutAsync(LogOutRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            await _tokenStoreService.RevokeUserBearerTokensAsync(userId.ToString(), request.RefreshToken);

            _antiforgery.DeleteAntiForgeryCookies();

            return _serviceResultHelper.Response(data: null,code: 100);
        }

        public async Task<ServiceResult> SignInViaRefreshTokenAsync(SignInViaRefreshTokenRequest request)
        {
            var response = new UserTokenResponse();
            if (string.IsNullOrWhiteSpace(request.RefreshToken))
                return _serviceResultHelper.Response(data: null, code: 100);

            var token = await _tokenStoreService.FindTokenAsync(request.RefreshToken);
            if (token == null)
                return _serviceResultHelper.Response(data: null, code: 100);

            var userResponse = await FindUserByIdAsync(token.UserId);
            var user = new User
            {
                Id = userResponse.Id,
                ProviderId = userResponse.ProviderId,
                Username = userResponse.Username,
                DisplayName = userResponse.DisplayName,
                ProviderName = userResponse.ProviderName,
                LastLoggedIn = userResponse.LastLoggedIn,
                SerialNumber = userResponse.SerialNumber
            };

            var result = await _tokenFactoryService.CreateJwtTokensAsync(user);
            await _tokenStoreService.AddUserTokenAsync(user, result.RefreshTokenSerial, result.AccessToken, _tokenFactoryService.GetRefreshTokenSerial(request.RefreshToken));

            _antiforgery.RegenerateAntiForgeryCookies(result.Claims);

            response.access_token = result.AccessToken;
            response.refresh_token = result.RefreshToken;

            return _serviceResultHelper.Response(response);
        }

        //public async Task<ServiceResult> ProviderAuthenticateAsync(ProviderAuthenticateRequest request)
        //{
        //    var response = await _repository.Sp_ProviderAuthentication(
        //        new ProviderAuthenticateParams()
        //        {
        //            Username = request.Username,
        //            Password = AppHelper.GetMD5HashData(request.Password)
        //        });

        //    var tokenResponse = new UserTokenResponse();
        //    if (response != null)
        //    {
        //        var userResponse = await FindUserByIdAsync(response.Id);
        //        var user = new User
        //        {
        //            Id = userResponse.Id,
        //            Username = userResponse.Username,
        //            DisplayName = userResponse.DisplayName,
        //            LastLoggedIn = userResponse.LastLoggedIn,
        //            SerialNumber = userResponse.SerialNumber,

        //        };
        //        var token = await _tokenFactoryService.CreateJwtTokensAsync(user);
        //        await _tokenStoreService.AddUserTokenAsync(user, token.RefreshTokenSerial, token.AccessToken, null);
        //        //antiforgery
        //        _antiforgery.RegenerateAntiForgeryCookies(token.Claims);

        //        tokenResponse.access_token = token.AccessToken;
        //        tokenResponse.refresh_token = token.RefreshToken;
        //    }
        //    return _serviceResultHelper.Response(tokenResponse);
        //}

        //public async Task<ServiceResult> AdminAuthenticateAsync(AdminAuthenticateRequest request)
        //{
        //    var response = await _repository.Sp_AdminAuthentication(
        //        new AdminAuthenticateParams()
        //        {
        //            Username = request.Username,
        //            Password = AppHelper.GetMD5HashData(request.Password)
        //        });

        //    //var securityToken = await _jwtService.GetSecurityToken(new JwtUserModel()
        //    //{
        //    //    Id = response.Id,
        //    //    Username = response.Username,
        //    //    Role = response.RoleName
        //    //});

        //    //response.Token = securityToken;
        //    return _serviceResultHelper.Response(response);
        //}

        #endregion Methods

    }
}
