using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.ProviderAbsorption;
using Core.Models.ViewModel.Business.ProviderAbsorption;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllProviderAbsorptionVm>> Sp_GetAllProviderAbsorption(GetAllProviderAbsorptionParam parameters) => await _context.GetManyWithPagingAsync<GetAllProviderAbsorptionVm>
                (
                    "Business.sp_GetAllProviderAbsorption",
                    parameters
        );
    }
}
