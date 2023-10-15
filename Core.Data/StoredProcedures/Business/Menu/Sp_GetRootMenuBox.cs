using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Menu;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetRootMenuBoxVm>> Sp_GetRootMenuBox() => await _context.GetManyAsync<GetRootMenuBoxVm>
                (
                    "Business.sp_GetRootMenuBox"
        );
    }
}
