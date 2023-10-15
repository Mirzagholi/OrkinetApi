using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductComment
{
    public class ReplyAdminProductCommentParam : BaseParam
    {
        public int ProductCommentId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
