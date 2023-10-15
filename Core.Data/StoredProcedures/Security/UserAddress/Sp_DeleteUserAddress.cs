using System.Threading.Tasks;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteUserAddressVm> Sp_DeleteUserAddress(DeleteUserAddressParam parameters) => await _context.GetAsync<DeleteUserAddressVm>
                (
                    "Security.sp_DeleteUserAddress",
                    parameters
                );
    }
}
