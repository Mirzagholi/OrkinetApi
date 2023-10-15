using Core.Common.Base;

namespace Core.Models.Request.Common.Sms
{
    public class PaidProviderOrderSmsRequest : BaseRequest
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
    }
}
