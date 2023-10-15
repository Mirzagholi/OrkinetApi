using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateUserVm> Sp_UpdateUser(UpdateUserParam parameters) => await _context.GetAsync<UpdateUserVm>
                (
                    "Security.sp_UpdateUser",
                    parameters
                );
    }
}
