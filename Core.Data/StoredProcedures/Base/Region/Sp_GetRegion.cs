using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Base.Region;
using Core.Models.ViewModel.Base.Region;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetRegionVm>> Sp_GetRegion(GetRegionParam parameters) => await _context.GetManyAsync<GetRegionVm>
            (
                "Base.sp_GetRegion",
                parameters
            );

    }

}
