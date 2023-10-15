using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<StartInquiryCartVm>> Sp_StartInquiryCart(StartInquiryCartParam parameters) => await _context.GetManyAsync<StartInquiryCartVm>
                (
                    "Business.sp_StartInquiryCart",
                    parameters
                );
    }
}
