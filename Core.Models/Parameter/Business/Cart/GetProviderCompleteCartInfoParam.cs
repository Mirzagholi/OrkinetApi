using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetProviderCompleteCartInfoParam : BaseParam
    {
        public int CartId { get; set; }
        public int ProviderId { get; set; }
    }
}
