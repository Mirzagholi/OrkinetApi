using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductDeliveryVm> Sp_UpdateProductDelivery(UpdateProductDeliveryParam parameters) => await _context.GetAsync<UpdateProductDeliveryVm>
                (
                    "Business.sp_UpdateProductDelivery",
                    parameters
                );
    }
}
