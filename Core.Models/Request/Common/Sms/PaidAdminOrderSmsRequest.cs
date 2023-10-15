using Core.Common.Base;

namespace Core.Models.Request.Common.Sms
{
    public class PaidAdminOrderSmsRequest : BaseRequest
    {
        public string MobileNumber { get; set; }
    }
}
