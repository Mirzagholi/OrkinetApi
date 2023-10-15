using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductDelivery
{
    public class AddProductDeliveryParam : BaseParam
    {
        public int Distance { get; set; }
        public int ProviderId { get; set; }
        public int? PurchasePrice { get; set; }
        public int Price { get; set; }
    }
}
