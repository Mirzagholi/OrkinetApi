using Core.Models.Parameter.Business.Cart;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<string>> Sp_GetAllInquiryProviderUserId(GetAllInquiryProviderUserIdParam parameters) => await _context.GetManyAsync<string>
        (
                "Business.Sp_GetAllInquiryProviderUserId",
                parameters
        );
    }
}