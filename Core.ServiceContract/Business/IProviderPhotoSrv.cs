using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;

namespace Core.ServiceContract.Business
{
    public interface IProviderPhotoSrv : IInjectableService
    {
        Task<ServiceResult> AddProviderPhotoAsync(AddProviderPhotoRequest request);
        Task<IEnumerable<GetProviderPhotoVm>> GetProviderPhotoAsync(GetProviderPhotoRequest request);
        Task<ServiceResult> DeleteProviderPhotoAsync(DeleteProviderPhotoRequest request);
    }
}
