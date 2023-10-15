using Core.Common.Base;

namespace Core.Models.Request.Business.ProductComment
{
    public class GetAllProductCommentUiRequest : BaseRequest
    {
        /// <summary>
        /// شماره نظر
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شماره صفحه جاری
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// تعداد رکورد ها جهت نمایش
        /// </summary>
        public int? PageRecord { get; set; }
    }
}
