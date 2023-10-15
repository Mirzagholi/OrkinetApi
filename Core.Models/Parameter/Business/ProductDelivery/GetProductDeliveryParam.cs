using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductDelivery
{
    public class GetProductDeliveryParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
