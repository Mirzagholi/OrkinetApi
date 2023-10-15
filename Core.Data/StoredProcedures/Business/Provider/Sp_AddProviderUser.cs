using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderUserVm> Sp_AddProviderUser(AddProviderUserParam parameters) => await _context.GetAsync<AddProviderUserVm>
                (
                    "Business.sp_AddProviderUser",
                    parameters
                );
    }
}
