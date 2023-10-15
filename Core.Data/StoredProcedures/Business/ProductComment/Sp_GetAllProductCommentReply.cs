using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetAllProductCommentReplyVm>>Sp_GetAllProductCommentReply(GetAllProductCommentReplyParam parameters) => await _context.GetManyAsync<GetAllProductCommentReplyVm>
            (
                "Business.sp_GetAllProductCommentReply",
                parameters
            );

    }

}
