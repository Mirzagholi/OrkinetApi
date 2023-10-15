using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Base.District;
using Core.Models.Parameter.Base.Region;
using Core.Models.ViewModel.Base.District;
using Core.Models.ViewModel.Base.Region;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetDistrictVm>> Sp_GetDistrict(GetDistrictParam parameters) => await _context.GetManyAsync<GetDistrictVm>
            (
                "Base.sp_GetDistrict",
                parameters
            );

    }

}
