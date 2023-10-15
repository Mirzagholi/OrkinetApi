using Core.Common.Base;

namespace Core.Models.Parameter.Common.ParbadStorage
{
    public class AddPaymentParam : BaseParam
    {
        public long TrackingNumber { get; set; }
        public decimal Amount { get; set; }
        public string Token { get; set; }
        public string TransactionCode { get; set; }
        public string GatewayName { get; set; }
        public string GatewayAccountName { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsPaid { get; set; }
    }
}
