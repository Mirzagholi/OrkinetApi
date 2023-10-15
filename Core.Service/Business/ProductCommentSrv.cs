using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Common.Extensions;
using Core.Common.ShareContract;
using Core.Common.ShareModels;
using Core.DataContract;
using Core.Models.Parameter.Business.ProductComment;
using Core.Models.Request.Business.Cart;
using Core.Models.Request.Business.ProductComment;
using Core.Models.ViewModel.Business.ProductComment;
using Core.ServiceContract.Business;

namespace Core.Service.Business
{
    public class ProductCommentSrv : IProductCommentSrv
    {

        #region Property

        private readonly IRepository _repository;
        private readonly IServiceResultHelper _serviceResultHelper;

        #endregion Property

        #region Constructor

        public ProductCommentSrv(IRepository repository,
            IServiceResultHelper serviceResultHelper)
        {
            _repository = repository;
            _serviceResultHelper = serviceResultHelper;
        }

        #endregion Constructor

        #region Methods

        public async Task<ServiceResult> AddUserProductCommentAsync(AddUserProductCommentRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            await _repository.Sp_AddUserProductComment(
                new AddUserProductCommentParam()
                {
                    ProductId = request.ProductId,
                    UserId = userId,
                    Text = request.Text,
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<BasePagingResult<GetAllProductCommentVm>> GetAllProductCommentAsync(GetAllProductCommentRequest request)
        {
            var results = await _repository.Sp_GetAllProductComment(new GetAllProductCommentParam
            {
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord,
                SortColumn = request.SortColumn,
                SortOrder = request.SortOrder
            });

            return new BasePagingResult<GetAllProductCommentVm>()
            {
                List = results.List,
                TotalCount = results.TotalCount
            };
        }

        public async Task<ServiceResult> UpdateProductCommentConfirmAsync(UpdateProductCommentConfirmRequest request)
        {
            await _repository.Sp_UpdateProductCommentConfirm(
                new UpdateProductCommentConfirmParam()
                {
                    Id = request.Id,
                    IsConfirm = request.IsConfirm
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<ServiceResult> ReplyAdminProductCommentAsync(ReplyAdminProductCommentRequest request)
        {
            var userId = HttpContextExtensions.GetUserId().Value;

            await _repository.Sp_ReplyAdminProductComment(
                new ReplyAdminProductCommentParam()
                {
                    ProductCommentId = request.ProductCommentId,
                    UserId = userId,
                    Text = request.Text
                });

            return _serviceResultHelper.Response(null);
        }

        public async Task<IEnumerable<GetAllProductCommentReplyVm>> GetAllProductCommentReplyAsync(int productCommentId) => 
            await _repository.Sp_GetAllProductCommentReply(new GetAllProductCommentReplyParam{ ProductCommentId = productCommentId });

        public async Task<BasePagingResult<GetAllProductCommentUiVm>> GetAllProductCommentUiAsync(GetAllProductCommentUiRequest request)
        {
            var results = await _repository.Sp_GetAllProductCommentUi(new GetAllProductCommentUiParam
            {
                Id = request.Id,
                PageNumber = request.PageNumber,
                PageRecord = request.PageRecord
            });

            if (results.List.Count() == 0)
                return results;

            var comments = results.List.ToList();
            foreach (var result in comments.Where(z => z.ReplyId != null).ToList())
            {
                comments.FirstOrDefault(z => z.Id == result.ReplyId).Replies.Add(result);
                comments.Remove(result);
            }
            results.List = comments;

            return results;
        }

        #endregion
    }
}
