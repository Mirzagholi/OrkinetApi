using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetAllProviderInquiryCartParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
