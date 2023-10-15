using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductDiscountVm> Sp_UpdateProductDiscount(UpdateProductDiscountParam parameters) => await _context.GetAsync<UpdateProductDiscountVm>
                (
                    "Business.sp_UpdateProductDiscount",
                    parameters
                );
    }
}
