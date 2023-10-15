using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Cart;
using Core.Models.Request.Business.ProviderAbsorption;
using Core.Models.ViewModel.Business.ProviderAbsorption;

namespace Core.ServiceContract.Business
{
    public interface IProviderAbsorptionSrv : IInjectableService
    {
        Task<ServiceResult> AddProviderAbsorptionAsync(AddProviderAbsorptionRequest request);

        Task<BasePagingResult<GetAllProviderAbsorptionVm>> GetAllProviderAbsorptionAsync(GetAllProviderAbsorptionRequest request);
    }
}
