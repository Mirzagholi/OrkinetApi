using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetCartBankResponseParam : BaseParam
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
