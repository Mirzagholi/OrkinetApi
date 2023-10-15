using Core.Common.Base;

namespace Core.Models.Request.Business.Favorite
{
    public class GetAllFavoriteUiRequest : BaseRequest
    {
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
