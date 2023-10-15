using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UserInquiryStatusVm> Sp_UserInquiryStatus(UserInquiryStatusParam parameters) => await _context.GetAsync<UserInquiryStatusVm>
                (
                    "Business.sp_UserInquiryStatus",
                    parameters
                );
    }
}
