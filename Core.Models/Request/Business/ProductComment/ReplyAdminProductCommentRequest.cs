using Core.Common.Base;

namespace Core.Models.Request.Business.ProductComment
{
    public class ReplyAdminProductCommentRequest : BaseRequest
    {
        /// <summary>
        /// شناسه نظر
        /// </summary>
        public int ProductCommentId { get; set; }

        /// <summary>
        /// متن نظر
        /// </summary>
        public string Text { get; set; }
    }
}
