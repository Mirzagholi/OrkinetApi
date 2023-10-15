using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductDiscount;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<int> Sp_GetProviderActiveProductDiscountCount(GetProviderActiveProductDiscountCountParam parameters) => await _context.GetAsync<int>
                (
                    "Business.sp_GetProviderActiveProductDiscountCount",
                    parameters
                );
    }
}
