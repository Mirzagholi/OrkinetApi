using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<LoginOrRegisterVm> Sp_LoginOrRegister(LoginOrRegisterParam parameters) => await _context.GetAsync<LoginOrRegisterVm>
                (
                    "Security.sp_LoginOrRegister",
                    parameters
                );
    }
}
