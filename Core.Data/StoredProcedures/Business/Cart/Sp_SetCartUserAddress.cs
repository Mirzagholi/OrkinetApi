using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<SetCartUserAddressVm> Sp_SetCartUserAddress(SetCartUserAddressParam parameters) => await _context.GetAsync<SetCartUserAddressVm>
                (
                    "Business.sp_SetCartUserAddress",
                    parameters
                );
    }
}
