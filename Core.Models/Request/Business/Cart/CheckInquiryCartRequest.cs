using Core.Common.Base;
using Core.Models.Enum.Business.Contact;
using System;

namespace Core.Models.Request.Business.Cart
{
    public class CheckInquiryCartRequest : BaseRequest
    {
        /// <summary>
        /// شناسه سبد خرید
        /// </summary>
        public int CartId { get; set; }
    }
}
