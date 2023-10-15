using System.Threading.Tasks;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddUserAddressVm> Sp_AddUserAddress(AddUserAddressParam parameters) => await _context.GetAsync<AddUserAddressVm>
                (
                    "Security.sp_AddUserAddress",
                    parameters
                );
    }
}
