using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateAttribute
{
    public class GetPrivateAttributeParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
