using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Security.UserAddress;
using Core.Models.ViewModel.Security.UserAddress;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetAllUserAddressVm>> Sp_GetAllUserAddress(GetAllUserAddressParam parameters) => await _context.GetManyAsync<GetAllUserAddressVm>
                (
                    "Security.sp_GetAllUserAddress",
                    parameters
                );
    }
}
