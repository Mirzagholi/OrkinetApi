using System;
using Core.Common.Base;

namespace Core.Models.Request.Business.ProductDiscount
{
    public class AddProductDiscountRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// مبلغ
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// تاریخ انقضاء
        /// </summary>
        public DateTime ExpiredOn { get; set; }
    }
}
