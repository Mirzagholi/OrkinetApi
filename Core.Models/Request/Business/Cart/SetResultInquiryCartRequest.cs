using Core.Common.Base;

namespace Core.Models.Request.Business.Cart
{
    public class SetResultInquiryCartRequest : BaseRequest
    {
        /// <summary>
        /// شناسه سبد خرید
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// وضعیت استعلام
        /// </summary>
        public bool IsConfirm { get; set; }
    }
}
