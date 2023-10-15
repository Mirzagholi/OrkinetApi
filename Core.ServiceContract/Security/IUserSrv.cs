using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.ServiceContract.Security
{
    public interface IUserSrv : IInjectableService
    {
        Task<FindUserByIdVm> FindUserByIdAsync(int id);

        Task UpdateUserLastActivityAsync(int id);

        Task<GetUserInfoVm> GetUserInfoAsync();

        Task<ServiceResult> AuthenticateAsync(AuthenticateRequest request);

        Task<ServiceResult> LoginOrRegisterAsync(LoginOrRegisterRequest request);

        Task<ServiceResult> UserActivationAsync(UserActivationRequest request);

        Task<ServiceResult> UserConfirmCodeAsync(UserConfirmCodeRequest request);

        Task<ServiceResult> ResetPasswordAsync(ResetPasswordRequest request);

        Task<ServiceResult> UpdateUserAsync(UpdateUserRequest request);

        Task<ServiceResult> SetPasswordAsync(SetPasswordRequest request);

        Task<ServiceResult> LogOutAsync(LogOutRequest request);

        Task<ServiceResult> SignInViaRefreshTokenAsync(SignInViaRefreshTokenRequest request);

        //Task<ServiceResult> ProviderAuthenticateAsync(ProviderAuthenticateRequest request);

        //Task<ServiceResult> AdminAuthenticateAsync(AdminAuthenticateRequest request);

    }
}
