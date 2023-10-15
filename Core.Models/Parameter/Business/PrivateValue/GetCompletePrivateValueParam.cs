using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateValue
{
    public class GetCompletePrivateValueParam: BaseParam
    {
        public int CategoryId { get; set; }
        public int ProviderId { get; set; }
    }
}
