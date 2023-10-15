using Core.Common.Base;

namespace Core.Models.Request.Common.Sms
{
    public class PaidOrderSmsRequest : BaseRequest
    {
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
    }
}
