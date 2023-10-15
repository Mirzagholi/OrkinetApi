using Core.Models.ViewModel.Business.PostalCart;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.ServiceContract.Business
{
    public interface IPostalCartSrv : IInjectableService
    {
        Task<IEnumerable<GetAllPostalCartVm>> GetAllPostalCartAsync();
    }
}
