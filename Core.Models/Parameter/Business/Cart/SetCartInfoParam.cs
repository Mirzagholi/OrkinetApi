using Core.Common.Base;
using System;

namespace Core.Models.Parameter.Business.Cart
{
    public class SetCartInfoParam : BaseParam
    {
        public int UserId { get; set; }
        public int CartId { get; set; }
        public int? PostalCartId { get; set; }
        public int CartDeliveryTypeId { get; set; }
        public int CartDeliveryPlaceTypeId { get; set; }
        public int CartFailedDeliveryTypeId { get; set; }
        public DateTime? DailyDeliveryStartOn { get; set; }
        public DateTime? DailyDeliveryEndOn { get; set; }
        public DateTime? TomorrowDeliveryOn { get; set; }
    }
}
