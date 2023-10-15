using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetProviderVm>> Sp_GetProvider(GetProviderParam parameters) => await _context.GetManyWithPagingAsync<GetProviderVm>
            (
                "Business.sp_GetProvider",
                parameters
        );

    }

}
