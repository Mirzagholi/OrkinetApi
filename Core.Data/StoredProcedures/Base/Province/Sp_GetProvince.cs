using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Base.Province;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProvinceVm>> Sp_GetProvince() => await _context.GetManyAsync<GetProvinceVm>
            (
                "Base.sp_GetProvince"
            );

    }

}
