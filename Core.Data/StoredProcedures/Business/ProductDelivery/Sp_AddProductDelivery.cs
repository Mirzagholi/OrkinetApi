using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDelivery;
using Core.Models.ViewModel.Business.ProductDelivery;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProductDeliveryVm> Sp_AddProductDelivery(AddProductDeliveryParam parameters) => await _context.GetAsync<AddProductDeliveryVm>
                (
                    "Business.sp_AddProductDelivery",
                    parameters
                );
    }
}
