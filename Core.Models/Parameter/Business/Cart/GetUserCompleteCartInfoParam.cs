using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class GetUserCompleteCartInfoParam : BaseParam
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
    }
}
