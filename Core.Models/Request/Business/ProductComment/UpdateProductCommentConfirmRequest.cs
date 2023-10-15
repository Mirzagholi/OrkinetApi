using Core.Common.Base;

namespace Core.Models.Request.Business.ProductComment
{
    public class UpdateProductCommentConfirmRequest : BaseRequest
    {
        /// <summary>
        /// شناسه نظر
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// وضعیت نظر
        /// </summary>
        public bool IsConfirm { get; set; }

    }
}
