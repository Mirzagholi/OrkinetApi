using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class SetResultInquiryCartParam : BaseParam
    {
        public int CartId { get; set; }
        public int ProviderId { get; set; }
        public int ProductId { get; set; }
        public bool IsConfirm { get; set; }
    }
}
