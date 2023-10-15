using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.Product;
using Core.Models.ViewModel.Business.Product;
using Core.Models.ViewModel.Business.Product.GetProviderProductById;

namespace Core.ServiceContract.Business
{
    public interface IProductSrv : IInjectableService
    {
        Task<ServiceResult> AddProductAsync(AddProductRequest request);
        Task<BasePagingResult<GetProductVm>> GetProductAsync(GetProductRequest request);
        Task<ServiceResult> UpdateProductAsync(UpdateProductRequest request);
        Task<ServiceResult> UpdateProductStatusAsync(UpdateProductStatusRequest request);
        Task<IEnumerable<GetProductDropDownVm>> GetProductDropDownAsync();
        Task<IEnumerable<GetLandingDiscountedProductVm>> GetLandingDiscountedProductAsync();
        Task<IEnumerable<GetLandingEconomicProductVm>> GetLandingEconomicProductAsync();
        Task<IEnumerable<GetLandingMostSalesProductVm>> GetLandingMostSalesProductAsync();
        Task<IEnumerable<GetLandingVipProductVm>> GetLandingVipProductAsync();
        Task<BasePagingResult<GetAllProductUiVm>> GetAllProductUiAsync(GetAllProductUiRequest request);
        Task<BasePagingResult<GetDiscountedProductUiVm>> GetDiscountedProductUiAsync(
            GetDiscountedProductUiRequest request);
        Task<BasePagingResult<GetNewestProductUiVm>> GetNewestProductUiAsync(GetNewestProductUiRequest request);
        Task<BasePagingResult<GetExpensiveProductUiVm>>
            GetExpensiveProductUiAsync(GetExpensiveProductUiRequest request);
        Task<BasePagingResult<GetCheapestProductUiVm>> GetCheapestProductUiAsync(GetCheapestProductUiRequest request);
        Task<GetProductDetailUiVm> GetProductDetailUiAsync(GetProductDetailUiRequest request);
        Task<IEnumerable<CheckProductForCartVm>> CheckProductForCartAsync(List<CheckProductForCartRequest> request);
        Task<BasePagingResult<GetAllProductForAdminVm>> GetAllProductForAdminAsync(GetAllProductForAdminRequest request);
        Task<ServiceResult> ConfirmProductAsync(ConfirmProductRequest request);
        Task<GetProviderProductByIdVm> GetProviderProductByIdAsync(int id);
    }
}
