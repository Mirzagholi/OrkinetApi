using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetProductDiscountVm>> Sp_GetProductDiscount(GetProductDiscountParam parameters) => await _context.GetManyWithPagingAsync<GetProductDiscountVm>
            (
                "Business.sp_GetProductDiscount",
                parameters
        );

    }

}
