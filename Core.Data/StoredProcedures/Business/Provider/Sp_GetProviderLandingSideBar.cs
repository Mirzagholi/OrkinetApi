using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProviderLandingSideBarVm>> Sp_GetProviderLandingSideBar() => await _context.GetManyAsync<GetProviderLandingSideBarVm>
            (
                "Business.sp_GetProviderLandingSideBar"
            );

    }

}
