using Core.Common.Base;

namespace Core.Models.Request.Common.Sms
{
    public class SendConfirmationSmsRequest : BaseRequest
    {
        public string MobileNumber { get; set; }

        public string ConfirmCode { get; set; }
    }
}
