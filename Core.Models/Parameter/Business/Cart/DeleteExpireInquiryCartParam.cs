using Core.Common.Base;
using System.Data;

namespace Core.Models.Parameter.Business.Cart
{
    public class DeleteExpireInquiryCartParam : BaseParam
    {
        public int RemainInquiryMinute { get; set; }
    }
}
