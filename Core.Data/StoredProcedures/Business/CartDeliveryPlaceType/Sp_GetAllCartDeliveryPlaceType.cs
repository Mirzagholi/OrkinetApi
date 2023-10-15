using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartDeliveryPlaceType;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetAllCartDeliveryPlaceTypeVm>> Sp_GetAllCartDeliveryPlaceType() => await _context.GetManyAsync<GetAllCartDeliveryPlaceTypeVm>
            (
                "Business.sp_GetAllCartDeliveryPlaceType"
            );
    }
}
