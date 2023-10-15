using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<ProviderAuthenticateVm> Sp_ProviderAuthentication(ProviderAuthenticateParam parameters) => await _context.GetAsync<ProviderAuthenticateVm>
                (
                    "Security.sp_ProviderAuthentication",
                    parameters
                );
    }
}
