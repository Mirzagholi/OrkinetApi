using Core.Common.Base;

namespace Core.Models.Request.Common.Sms
{
    public class SendInquirySmsRequest : BaseRequest
    {
        public string MobileNumber { get; set; }
        public string FullName { get; set; }
    }
}
