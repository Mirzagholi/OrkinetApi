using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AuthenticateVm> Sp_Authentication(AuthenticateParam parameters) => await _context.GetAsync<AuthenticateVm>
                (
                    "Security.sp_Authentication",
                    parameters
                );
    }
}
