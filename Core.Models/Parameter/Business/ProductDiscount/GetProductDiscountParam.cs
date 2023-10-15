using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductDiscount
{
    public class GetProductDiscountParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
