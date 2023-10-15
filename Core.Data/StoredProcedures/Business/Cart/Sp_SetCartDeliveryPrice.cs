using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<SetCartDeliveryPriceVm>> Sp_SetCartDeliveryPrice(SetCartDeliveryPriceParam parameters) => await _context.GetManyAsync<SetCartDeliveryPriceVm>
                (
                    "Business.sp_SetCartDeliveryPrice",
                    parameters
                );
    }
}
