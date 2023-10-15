using Core.Common.Base;

namespace Core.Models.Request.Business.ProductDelivery
{
    public class UpdateProductDeliveryRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محدوده ارسال پیک
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// فاصله به کیلومتر
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// مبلغ بر اساس سبد خرید
        /// </summary>
        public int? PurchasePrice { get; set; }

        /// <summary>
        /// مبلغ
        /// </summary>
        public int Price { get; set; }
    }
}
