using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.SideBar;
using Core.Models.ViewModel.Business.Category;
using Core.Models.ViewModel.Business.Menu;
using Core.Models.ViewModel.Business.SideBar;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetLandingSideBarVm>> Sp_GetLandingSideBar(GetLandingSideBarParam parameters) => await _context.GetManyAsync<GetLandingSideBarVm>
                (
                    "Business.sp_GetLandingSideBar",
                    parameters
        );
    }
}
