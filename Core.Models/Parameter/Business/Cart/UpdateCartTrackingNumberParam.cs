using Core.Common.Base;

namespace Core.Models.Parameter.Business.Cart
{
    public class UpdateCartTrackingNumberParam : BaseParam
    {
        public int CartId { get; set; }
        public long TrackingNumber { get; set; }
    }
}
