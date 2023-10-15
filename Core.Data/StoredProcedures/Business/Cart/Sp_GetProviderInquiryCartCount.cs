using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<int> Sp_GetProviderInquiryCartCount(GetProviderInquiryCartCountParam parameters) => await _context.GetAsync<int>
                (
                    "Business.sp_GetProviderInquiryCartCount",
                    parameters
                );
    }
}
