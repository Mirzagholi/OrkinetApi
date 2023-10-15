using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductComment
{
    public class AddUserProductCommentParam : BaseParam
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
