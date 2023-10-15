using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.ShareModels;
using Core.Models.ViewModel.Business.Menu;

namespace Core.ServiceContract.Business
{
    public interface IMenuSrv : IInjectableService
    {
        Task<IEnumerable<GetRootMenuBoxVm>> GetRootMenuBoxAsync();
        Task<IEnumerable<GetSubMenuBoxVm>> GetSubMenuBoxAsync(int id);
        Task<IEnumerable<GetLandingMenuVm>> GetLandingMenuAsync();
    }
}
