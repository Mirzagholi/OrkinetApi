using Core.Models.Parameter.Security.UserRole;
using Core.Models.ViewModel.Security.UserRole;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetUserRoleVm>> Sp_GetUserRole(GetUserRoleParam parameters) => await _context.GetManyAsync<GetUserRoleVm>
        (
                "Security.sp_GetUserRole",
                parameters
        );

    }

}
