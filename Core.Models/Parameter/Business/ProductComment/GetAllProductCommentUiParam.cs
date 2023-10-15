using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductComment
{
    public class GetAllProductCommentUiParam : BaseParam
    {
        public int Id { get; set; }
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
    }
}
