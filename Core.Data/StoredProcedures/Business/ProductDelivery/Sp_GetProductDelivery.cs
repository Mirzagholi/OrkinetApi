using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetProductDeliveryVm>> Sp_GetProductDelivery(GetProductDeliveryParam parameters) => await _context.GetManyWithPagingAsync<GetProductDeliveryVm>
            (
                "Business.sp_GetProductDelivery",
                parameters
        );

    }

}
