using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Base.Province;
using Core.Models.ViewModel.Base.Region;

namespace Core.ServiceContract.Base
{
    public interface IProvinceSrv : IInjectableService
    {

        Task<IEnumerable<GetProvinceVm>> GetProvinceAsync();

    }
}
