using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartFailedDeliveryType;

namespace Core.ServiceContract.Business
{
    public interface ICartFailedDeliveryTypeSrv : IInjectableService
    {
        Task<IEnumerable<GetAllCartFailedDeliveryTypeVm>> GetAllCartFailedDeliveryTypeAsync();
    }
}
