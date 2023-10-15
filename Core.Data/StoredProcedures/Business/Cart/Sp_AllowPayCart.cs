using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<bool> Sp_AllowPayCart(AllowPayCartParam parameters) => await _context.GetAsync<bool>
                (
                    "Business.sp_AllowPayCart",
                    parameters
                );
    }
}
