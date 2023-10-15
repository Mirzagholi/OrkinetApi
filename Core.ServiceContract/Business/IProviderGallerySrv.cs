using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProviderGallery;
using Core.Models.ViewModel.Business.ProviderGallery;

namespace Core.ServiceContract.Business
{
    public interface IProviderGallerySrv : IInjectableService
    {
        Task<ServiceResult> AddProviderGalleryAsync(AddProviderGalleryRequest request);
        Task<IEnumerable<GetProviderGalleryVm>> GetProviderGalleryAsync(GetProviderGalleryRequest request);
        Task<IEnumerable<GetProviderGalleryVm>> GetProviderGalleryProAsync();
        Task<ServiceResult> UpdateProviderGalleryStatusAsync(UpdateProviderGalleryStatusRequest request);
    }
}
