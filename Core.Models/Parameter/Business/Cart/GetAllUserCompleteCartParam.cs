using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetAllUserCompleteCartParam : BaseParam
    {
        public int UserId { get; set; }
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
    }
}
