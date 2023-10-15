using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductComment
{
    public class UpdateProductCommentConfirmParam : BaseParam
    {
        public int Id { get; set; }
        public bool IsConfirm { get; set; }
    }
}
