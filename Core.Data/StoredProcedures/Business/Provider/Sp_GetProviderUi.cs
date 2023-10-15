using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProviderUiVm>> Sp_GetProviderUi() => await _context.GetManyAsync<GetProviderUiVm>
            (
                "Business.sp_GetProviderUi"
        );

    }

}
