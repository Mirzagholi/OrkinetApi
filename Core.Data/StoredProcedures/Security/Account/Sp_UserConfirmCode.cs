using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UserConfirmCodeVm> Sp_UserConfirmCode(UserConfirmCodeParam parameters) => await _context.GetAsync<UserConfirmCodeVm>
                (
                    "Security.sp_UserConfirmCode",
                    parameters
                );
    }
}
