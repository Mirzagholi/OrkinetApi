using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<int>> Sp_GetAllUserActiveInquiryCartId(GetAllUserActiveInquiryCartIdParam parameters) => await _context.GetManyAsync<int>
                (
                    "Business.sp_GetAllUserActiveInquiryCartId",
                    parameters
                );
    }
}
