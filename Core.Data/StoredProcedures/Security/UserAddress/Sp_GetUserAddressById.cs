using System.Threading.Tasks;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<GetUserAddressByIdVm> Sp_GetUserAddressById(GetUserAddressByIdParam parameters) => await _context.GetAsync<GetUserAddressByIdVm>
                (
                    "Security.sp_GetUserAddressById",
                    parameters
                );
    }
}
