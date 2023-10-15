using System.Threading.Tasks;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductStatusVm> Sp_UpdateProductStatus(UpdateProductStatusParam parameters) => await _context.GetAsync<UpdateProductStatusVm>
                (
                    "Business.sp_UpdateProductStatus",
                    parameters
                );
    }
}
