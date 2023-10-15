using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.SideBar;

namespace Core.ServiceContract.Business
{
    public interface ISideBarSrv : IInjectableService
    {
        Task<IEnumerable<GetLandingSideBarVm>> GetLandingSideBarAsync(int menuId);
    }
}
