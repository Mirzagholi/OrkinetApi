using Core.Models.Parameter.Business.Cart;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<int> Sp_GetProviderCustomerCartCount(GetProviderCustomerCartCountParam parameters) => await _context.GetAsync<int>
            (
                "Business.sp_GetProviderCustomerCartCount",
                parameters
            );
    }
}
