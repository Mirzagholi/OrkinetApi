using System.Threading.Tasks;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProductVm> Sp_AddProduct(AddProductParam parameters) => await _context.GetAsync<AddProductVm>
                (
                    "Business.sp_AddProduct",
                    parameters
                );
    }
}
