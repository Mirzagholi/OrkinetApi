using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.CartDeliveryType;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetAllCartDeliveryTypeVm>> Sp_GetAllCartDeliveryType() => await _context.GetManyAsync<GetAllCartDeliveryTypeVm>
            (
                "Business.sp_GetAllCartDeliveryType"
            );
    }
}
