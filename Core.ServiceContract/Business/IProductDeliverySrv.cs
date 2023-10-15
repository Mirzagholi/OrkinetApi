using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;

namespace Core.ServiceContract.Business
{
    public interface IProductDeliverySrv : IInjectableService
    {
        Task<ServiceResult> AddProductDeliveryAsync(AddProductDeliveryRequest request);
        Task<BasePagingResult<GetProductDeliveryVm>> GetProductDeliveryAsync(GetProductDeliveryRequest request);
        Task<ServiceResult> UpdateProductDeliveryAsync(UpdateProductDeliveryRequest request);
        Task<ServiceResult> UpdateProductDeliveryStatusAsync(UpdateProductDeliveryStatusRequest request);
    }
}
