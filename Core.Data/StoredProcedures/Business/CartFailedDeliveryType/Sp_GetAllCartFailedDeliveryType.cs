using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartFailedDeliveryType;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetAllCartFailedDeliveryTypeVm>> Sp_GetAllCartFailedDeliveryType() => await _context.GetManyAsync<GetAllCartFailedDeliveryTypeVm>
            (
                "Business.sp_GetAllCartFailedDeliveryType"
            );
    }
}
