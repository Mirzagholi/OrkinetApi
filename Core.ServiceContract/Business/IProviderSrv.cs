using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Provider;
using Core.Models.ViewModel.Business.Product;
using Core.Models.ViewModel.Business.Provider;

namespace Core.ServiceContract.Business
{
    public interface IProviderSrv : IInjectableService
    {
        Task<ServiceResult> AddProviderAsync(AddProviderRequest request);
        Task<BasePagingResult<GetProviderVm>> GetProviderAsync(GetProviderRequest request);
        Task<ServiceResult> SetProviderCoordinateAsync(SetProviderCoordinateRequest request);
        Task<ServiceResult> AddProviderUserMobileAsync(AddProviderUserMobileRequest request);
        Task<ServiceResult> ConfirmProviderUserMobileAsync(ConfirmProviderUserMobileRequest request);
        Task<ServiceResult> AddProviderUserAsync(AddProviderUserRequest request);
        Task<GetProviderInfoVm> GetProviderInfoAsync();
        Task<ServiceResult> UpdateProviderInfoAsync(UpdateProviderInfoRequest request);
        Task<BasePagingResult<GetActiveProviderVm>> GetActiveProviderAsync(GetActiveProviderRequest request);
        Task<IEnumerable<GetProviderUiVm>> GetProviderUiAsync();
        Task<IEnumerable<GetClosestProviderUiVm>> GetClosestProviderUiAsync(GetClosestProviderUiRequest request);
        Task<IEnumerable<GetProviderLandingSideBarVm>> GetProviderLandingSideBarAsync();
        Task<GetProviderDetailUiVm> GetProviderDetailUiAsync(GetProviderDetailUiRequest request);
    }
}
