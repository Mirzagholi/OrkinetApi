using System.Threading.Tasks;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateUserAddressVm> Sp_UpdateUserAddress(UpdateUserAddressParam parameters) => await _context.GetAsync<UpdateUserAddressVm>
                (
                    "Security.sp_UpdateUserAddress",
                    parameters
                );
    }
}
