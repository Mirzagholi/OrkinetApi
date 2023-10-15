using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseProductPagingResult<GetProductVm, GetProductAttrValVm, GetProductPrivateAttrValVm, GetProductPhotosVm, GetProductCategoryVm>>
            Sp_GetProduct(GetProductParam parameters) => await _context.GetManyProductWithPagingAsync<GetProductVm, GetProductAttrValVm ,GetProductPrivateAttrValVm, GetProductPhotosVm, GetProductCategoryVm>
            (
                "Business.sp_GetProduct",
                parameters
            );

    }

}
