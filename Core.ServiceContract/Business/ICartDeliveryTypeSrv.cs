using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartDeliveryType;

namespace Core.ServiceContract.Business
{
    public interface ICartDeliveryTypeSrv : IInjectableService
    {
        Task<IEnumerable<GetAllCartDeliveryTypeVm>> GetAllCartDeliveryTypeAsync();
    }
}
