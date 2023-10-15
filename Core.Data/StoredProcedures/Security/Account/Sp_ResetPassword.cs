using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<ResetPasswordVm> Sp_ResetPassword(ResetPasswordParam parameters) => await _context.GetAsync<ResetPasswordVm>
                (
                    "Security.sp_ResetPassword",
                    parameters
                );
    }
}
