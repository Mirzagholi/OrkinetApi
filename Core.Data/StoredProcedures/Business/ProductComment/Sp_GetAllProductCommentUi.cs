using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetAllProductCommentUiVm>> Sp_GetAllProductCommentUi(GetAllProductCommentUiParam parameters) => await _context.GetManyWithPagingAsync<GetAllProductCommentUiVm>
            (
                "Business.sp_GetAllProductCommentUi",
                parameters
            );

    }

}
