using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<string> Sp_GetCartBankResponse(GetCartBankResponseParam parameters) => await _context.GetAsync<string>
                (
                    "Business.sp_GetCartBankResponse",
                    parameters
                );
    }
}
