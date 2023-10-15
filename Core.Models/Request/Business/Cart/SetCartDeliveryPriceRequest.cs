using Core.Common.Base;

namespace Core.Models.Request.Business.Cart
{
    public class SetCartDeliveryPriceRequest : BaseRequest
    {
        /// <summary>
        /// شناسه سبد خرید
        /// </summary>
        public int CartId { get; set; }
    }
}
