using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;

namespace Core.ServiceContract.Business
{
    public interface IProductDiscountSrv : IInjectableService
    {
        Task<ServiceResult> AddProductDiscountAsync(AddProductDiscountRequest request);

        Task<BasePagingResult<GetProductDiscountVm>> GetProductDiscountAsync(GetProductDiscountRequest request);

        Task<ServiceResult> UpdateProductDiscountAsync(UpdateProductDiscountRequest request);

        Task<ServiceResult> UpdateProductDiscountStatusAsync(UpdateProductDiscountStatusRequest request);

        Task<int> GetProviderActiveProductDiscountCountAsync();
    }
}
