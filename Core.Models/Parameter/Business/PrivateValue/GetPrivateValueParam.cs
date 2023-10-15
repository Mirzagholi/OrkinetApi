using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateValue
{
    public class GetPrivateValueParam : BasePagingParam
    {
        public int ProviderId { get; set; }
    }
}
