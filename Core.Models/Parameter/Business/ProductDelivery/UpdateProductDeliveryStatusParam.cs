using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.ProductDelivery
{
    public class UpdateProductDeliveryStatusParam : BaseParam
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public StatusType StatusId { get; set; }
    }
}
