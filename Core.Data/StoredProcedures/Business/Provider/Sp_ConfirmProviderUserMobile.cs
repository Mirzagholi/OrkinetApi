using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<ConfirmProviderUserMobileVm> Sp_ConfirmProviderUserMobile(ConfirmProviderUserMobileParam parameters) => await _context.GetAsync<ConfirmProviderUserMobileVm>
                (
                    "Business.sp_ConfirmProviderUserMobile",
                    parameters
                );
    }
}
