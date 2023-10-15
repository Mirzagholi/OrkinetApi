using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Base.City;

namespace Core.ServiceContract.Base
{
    public interface ICitySrv : IInjectableService
    {
        Task<IEnumerable<GetCityVm>> GetCityAsync(int provinceId);
    }
}
