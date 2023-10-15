using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.ShareModels;
using Core.Models.Request.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;

namespace Core.ServiceContract.Business
{
    public interface IProductCommentSrv : IInjectableService
    {
        Task<ServiceResult> AddUserProductCommentAsync(AddUserProductCommentRequest request);
        Task<BasePagingResult<GetAllProductCommentVm>> GetAllProductCommentAsync(GetAllProductCommentRequest request);
        Task<ServiceResult> UpdateProductCommentConfirmAsync(UpdateProductCommentConfirmRequest request);
        Task<ServiceResult> ReplyAdminProductCommentAsync(ReplyAdminProductCommentRequest request);
        Task<IEnumerable<GetAllProductCommentReplyVm>> GetAllProductCommentReplyAsync(int productCommentId);
        Task<BasePagingResult<GetAllProductCommentUiVm>> GetAllProductCommentUiAsync(GetAllProductCommentUiRequest request);
    }
}
