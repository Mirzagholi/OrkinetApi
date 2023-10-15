using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Menu;
using Core.Models.ViewModel.Business.Menu;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetSubMenuBoxVm>> Sp_GetSubMenuBox(GetSubMenuBoxParam parameters) => await _context.GetManyAsync<GetSubMenuBoxVm>
            (
                "Business.sp_GetSubMenuBox",
                parameters
            );

    }

}
