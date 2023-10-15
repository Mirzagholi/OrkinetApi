using Core.Common.Base;

namespace Core.Models.Request.Business.Product
{
    public class CheckProductForCartRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصولات
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// مبلغ محصولات
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// تخفیف
        /// </summary>
        public int DiscountPrice { get; set; }
    }
}
