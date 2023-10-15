using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<SetPasswordVm> Sp_SetPassword(SetPasswordParam parameters) => await _context.GetAsync<SetPasswordVm>
                (
                    "Security.sp_SetPassword",
                    parameters
                );
    }
}
