using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductPrice
{
    public class UpdateProductPriceParam : BaseParam
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int ProviderId { get; set; }
    }
}
