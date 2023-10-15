using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetProviderInfoVm> Sp_GetProviderInfo(GetProviderInfoParam parameters) => await _context.GetAsync<GetProviderInfoVm>
            (
                "Business.sp_GetProviderInfo",
                parameters
            );

    }

}
