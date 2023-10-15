using System.Threading.Tasks;
using Core.Models.ViewModel.Security.User;
using Core.Models.Request.Security.Provider;
using Core.Common.ShareModels;

namespace Core.ServiceContract.Security
{
    public interface IProviderSrv : IInjectableService
    {
        //Task<GetUserByIdVm> GetProviderByIdAsync(int id);

        //Task<ServiceResult> ProviderAuthenticateAsync(AuthenticateRequest request);

        Task<ServiceResult> ProviderRegisterAsync(ProviderRegisterRequest request);

        Task<ServiceResult> ProviderActivationAsync(ProviderActivationRequest request);

    }
}
