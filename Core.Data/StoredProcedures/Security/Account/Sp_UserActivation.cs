using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<UserActivationVm> Sp_UserActivation(UserActivationParam parameters)
        {
            return await _context.GetAsync<UserActivationVm>
            (
                "Security.sp_UserActivation",
                parameters
            );
        }
    }
}
