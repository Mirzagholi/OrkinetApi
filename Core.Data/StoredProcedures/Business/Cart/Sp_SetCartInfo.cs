using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<SetCartInfoVm> Sp_SetCartInfo(SetCartInfoParam parameters) => await _context.GetAsync<SetCartInfoVm>
                (
                    "Business.sp_SetCartInfo",
                    parameters
                );
    }
}
