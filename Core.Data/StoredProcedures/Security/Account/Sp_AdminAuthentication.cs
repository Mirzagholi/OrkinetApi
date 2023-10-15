using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AdminAuthenticateVm> Sp_AdminAuthentication(AdminAuthenticateParam parameters) => await _context.GetAsync<AdminAuthenticateVm>
                (
                    "Security.sp_AdminAuthentication",
                    parameters
                );
    }
}
