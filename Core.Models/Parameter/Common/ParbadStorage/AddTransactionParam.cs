using Core.Common.Base;

namespace Core.Models.Parameter.Common.ParbadStorage
{
    public class AddTransactionParam : BaseParam
    {
        public decimal Amount { get; set; }
        public int Type { get; set; }
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public string AdditionalData { get; set; }
        public int PaymentId { get; set; }
    }
}
