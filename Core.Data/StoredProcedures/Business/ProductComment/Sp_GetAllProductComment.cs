using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetAllProductCommentVm>>Sp_GetAllProductComment(GetAllProductCommentParam parameters) => await _context.GetManyWithPagingAsync<GetAllProductCommentVm>
            (
                "Business.sp_GetAllProductComment",
                parameters
            );

    }

}
