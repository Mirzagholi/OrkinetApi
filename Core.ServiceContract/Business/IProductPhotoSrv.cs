using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPhoto;

namespace Core.ServiceContract.Business
{
    public interface IProductPhotoSrv : IInjectableService
    {
        Task<ServiceResult> AddProductPhotoAsync(AddProductPhotoRequest request);
        Task<IEnumerable<GetProductPhotoVm>> GetProductPhotoAsync(GetProductPhotoRequest request);
        Task<ServiceResult> DeleteProductPhotoAsync(DeleteProductPhotoRequest request);
    }
}
