using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Base.Region;

namespace Core.ServiceContract.Base
{
    public interface IRegionSrv : IInjectableService
    {

        Task<IEnumerable<GetRegionVm>> GetRegionAsync(int cityId);

    }
}
