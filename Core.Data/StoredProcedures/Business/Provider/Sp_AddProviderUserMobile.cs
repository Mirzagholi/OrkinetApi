using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderUserMobileVm> Sp_AddProviderUserMobile(AddProviderUserMobileParam parameters) => await _context.GetAsync<AddProviderUserMobileVm>
                (
                    "Business.sp_AddProviderUserMobile",
                    parameters
                );
    }
}
