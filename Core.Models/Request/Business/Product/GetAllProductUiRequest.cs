using Core.Common.Base;

namespace Core.Models.Request.Business.Product
{
    /// <summary>
    /// پارامتر های ورودی سرویس دریافت محصولات برای نمایش در صفحه محصولات لندینگ
    /// </summary>
    public class GetAllProductUiRequest : BaseRequest
    {
        /// <summary>
        /// شناسه دسته
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// حداقل مبلغ
        /// </summary>
        public int? StartingPrice { get; set; }

        /// <summary>
        /// حداکثر مبلغ
        /// </summary>
        public int? EndingPrice { get; set; }

        /// <summary>
        /// شناسه تامین کنندگان
        /// </summary>
        public string[] ProviderIdes { get; set; }

        /// <summary>
        /// شناسه های ساید بار
        /// </summary>
        public string[] SideBarIdes { get; set; }

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
