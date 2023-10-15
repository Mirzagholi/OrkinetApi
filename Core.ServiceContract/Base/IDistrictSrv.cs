using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Base.District;
using Core.Models.ViewModel.Base.Region;

namespace Core.ServiceContract.Base
{
    public interface IDistrictSrv : IInjectableService
    {

        Task<IEnumerable<GetDistrictVm>> GetDistrictAsync(int cityId);

    }
}
