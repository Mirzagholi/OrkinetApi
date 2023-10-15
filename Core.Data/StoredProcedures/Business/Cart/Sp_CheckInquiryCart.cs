using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<CheckInquiryCartVm>> Sp_CheckInquiryCart(CheckInquiryCartParam parameters) => await _context.GetManyAsync<CheckInquiryCartVm>
                (
                    "Business.sp_CheckInquiryCart",
                    parameters
                );
    }
}
