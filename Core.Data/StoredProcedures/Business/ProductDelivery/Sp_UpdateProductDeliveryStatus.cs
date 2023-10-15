using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductDeliveryStatusVm> Sp_UpdateProductDeliveryStatus(UpdateProductDeliveryStatusParam parameters) => await _context.GetAsync<UpdateProductDeliveryStatusVm>
                (
                    "Business.sp_UpdateProductDeliveryStatus",
                    parameters
                );
    }
}
