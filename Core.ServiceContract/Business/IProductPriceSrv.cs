using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProductPrice;

namespace Core.ServiceContract.Business
{
    public interface IProductPriceSrv : IInjectableService
    {
        Task<ServiceResult> UpdateProductPriceAsync(UpdateProductPriceRequest request);
    }
}
