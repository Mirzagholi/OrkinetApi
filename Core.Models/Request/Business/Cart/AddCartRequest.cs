using Core.Common.Base;
using Core.Models.Enum.Business.Contact;
using System;

namespace Core.Models.Request.Business.Cart
{
    public class AddCartRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصولات
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// تعداد محصول
        /// </summary>
        public int Quantity { get; set; }
    }
}
