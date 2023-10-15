using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductDiscountStatusVm> Sp_UpdateProductDiscountStatus(UpdateProductDiscountStatusParam parameters) => await _context.GetAsync<UpdateProductDiscountStatusVm>
                (
                    "Business.sp_UpdateProductDiscountStatus",
                    parameters
                );
    }
}
