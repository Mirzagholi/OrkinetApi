using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDiscount;
using Core.Models.ViewModel.Business.ProductDiscount;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProductDiscountVm> Sp_AddProductDiscount(AddProductDiscountParam parameters) => await _context.GetAsync<AddProductDiscountVm>
                (
                    "Business.sp_AddProductDiscount",
                    parameters
                );
    }
}
