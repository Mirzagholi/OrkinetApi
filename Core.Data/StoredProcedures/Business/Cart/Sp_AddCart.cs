using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddCartVm> Sp_AddCart(AddCartParam parameters) => await _context.GetAsync<AddCartVm>
                (
                    "Business.sp_AddCart",
                    parameters
                );
    }
}
