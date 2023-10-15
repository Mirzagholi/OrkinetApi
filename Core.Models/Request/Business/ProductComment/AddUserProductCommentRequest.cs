using Core.Common.Base;

namespace Core.Models.Request.Business.ProductComment
{
    public class AddUserProductCommentRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// متن نظر
        /// </summary>
        public string Text { get; set; }
    }
}
