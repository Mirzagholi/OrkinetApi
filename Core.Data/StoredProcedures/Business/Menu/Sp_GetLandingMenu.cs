using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Category;
using Core.Models.ViewModel.Business.Menu;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetLandingMenuVm>> Sp_GetLandingMenu() => await _context.GetManyAsync<GetLandingMenuVm>
                (
                    "Business.sp_GetLandingMenu"
        );
    }
}
