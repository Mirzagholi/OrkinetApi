using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class CancelInquiryCartParam : BaseParam
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
