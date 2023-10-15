using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Security.UserRole;

namespace Core.ServiceContract.Security
{
    public interface IUserRoleSrv : IInjectableService
    {
        Task<IEnumerable<GetUserRoleVm>> FindUserRolesAsync(int userId);
    }
}
