using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<SetResultInquiryCartVm> Sp_SetResultInquiryCart(SetResultInquiryCartParam parameters) => await _context.GetAsync<SetResultInquiryCartVm>
                (
                    "Business.sp_SetResultInquiryCart",
                    parameters
                );
    }
}
