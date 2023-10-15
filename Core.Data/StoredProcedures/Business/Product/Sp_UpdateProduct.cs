using System.Threading.Tasks;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProductVm> Sp_UpdateProduct(UpdateProductParam parameters) => await _context.GetAsync<UpdateProductVm>
                (
                    "Business.sp_UpdateProduct",
                    parameters
                );
    }
}
