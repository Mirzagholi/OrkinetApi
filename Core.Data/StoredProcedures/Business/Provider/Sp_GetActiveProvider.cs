using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetActiveProviderVm>> Sp_GetActiveProvider(GetActiveProviderParam parameters) => await _context.GetManyWithPagingAsync<GetActiveProviderVm>
            (
                "Business.sp_GetActiveProvider",
                parameters
        );

    }

}
