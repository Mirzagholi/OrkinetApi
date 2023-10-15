using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderVm> Sp_AddProvider(AddProviderParam parameters) => await _context.GetAsync<AddProviderVm>
                (
                    "Business.sp_AddProvider",
                    parameters
                );
    }
}
