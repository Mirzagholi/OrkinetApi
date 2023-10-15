using System;
using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductDiscount
{
    public class AddProductDiscountParam : BaseParam
    {
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Value { get; set; }
        public DateTime ExpiredOn { get; set; }
    }
}
