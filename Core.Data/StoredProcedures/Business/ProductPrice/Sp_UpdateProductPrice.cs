using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductPrice;
using Core.Models.ViewModel.Business.ProductPrice;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductPriceVm> Sp_UpdateProductPrice(UpdateProductPriceParam parameters) => await _context.GetAsync<UpdateProductPriceVm>
                (
                    "Business.sp_UpdateProductPrice",
                    parameters
                );
    }
}
