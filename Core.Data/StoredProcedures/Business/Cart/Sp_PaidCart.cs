using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<PaidCartVm> Sp_PaidCart(PaidCartParam parameters) => await _context.GetAsync<PaidCartVm>
                (
                    "Business.sp_PaidCart",
                    parameters
                );
    }
}
