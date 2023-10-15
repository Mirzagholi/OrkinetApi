using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProviderInfoVm> Sp_UpdateProviderInfo(UpdateProviderInfoParam parameters) => await _context.GetAsync<UpdateProviderInfoVm>
                (
                    "Business.sp_UpdateProviderInfo",
                    parameters
                );
    }
}
