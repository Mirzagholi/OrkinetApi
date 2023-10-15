using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<int?> Sp_GetCartTotalPrice(GetCartTotalPriceParam parameters) => await _context.GetAsync<int?>
                (
                    "Business.sp_GetCartTotalPrice",
                    parameters
                );
    }
}
