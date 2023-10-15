using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartDeliveryPlaceType;

namespace Core.ServiceContract.Business
{
    public interface ICartDeliveryPlaceTypeSrv : IInjectableService
    {
        Task<IEnumerable<GetAllCartDeliveryPlaceTypeVm>> GetAllCartDeliveryPlaceTypeAsync();
    }
}
