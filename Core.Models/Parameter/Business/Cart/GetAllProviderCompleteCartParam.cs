using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetAllProviderCompleteCartParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
