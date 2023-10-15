using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetDiscountedProductUiVm>> Sp_GetDiscountedProductUi(GetDiscountedProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetDiscountedProductUiVm>
            (
                "Business.sp_GetDiscountedProductUi",
                parameters
            );

    }

}
