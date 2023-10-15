using System;
using Core.Common.Base;

namespace Core.Models.Request.Business.ProductDiscount
{
    public class UpdateProductDiscountRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تخفیف
        /// </summary>
        public int Id { get; set; }

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
