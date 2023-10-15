using Core.Common.Base;

namespace Core.Models.Parameter.Common.ParbadStorage
{
    public class UpdatePaymentParam : BaseParam
    {
        public int Id { get; set; }
        public long TrackingNumber { get; set; }
        public string Token { get; set; }
        public string TransactionCode { get; set; }
        public string GatewayAccountName { get; set; }
    }
}
