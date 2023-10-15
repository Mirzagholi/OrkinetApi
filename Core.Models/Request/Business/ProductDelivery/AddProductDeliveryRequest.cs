using Core.Common.Base;

namespace Core.Models.Request.Business.ProductDelivery
{
    public class AddProductDeliveryRequest : BaseRequest
    {
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
