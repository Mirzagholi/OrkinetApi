using Core.Models.Parameter.Business.Cart;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_DeleteExpireInquiryCart(DeleteExpireInquiryCartParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_DeleteExpireInquiryCart",
                    parameters
                );
    }
}
