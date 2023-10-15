using Core.Common.Base;
using System;

namespace Core.Models.Request.Business.Cart
{
    public class SetCartInfoRequest : BaseRequest
    {
        /// <summary>
        /// شناسه سبد خرید
        /// </summary>
        public int CartId { get; set; }

        /// <summary>
        /// شناسه کارت پستال
        /// </summary>
        public int? PostalCartId { get; set; }

        /// <summary>
        /// شناسه نحوه ارسال
        /// </summary>
        public int CartDeliveryTypeId { get; set; }

        /// <summary>
        /// شناسه نوع محل ارسال
        /// </summary>
        public int CartDeliveryPlaceTypeId { get; set; }

        /// <summary>
        /// شناسه حالات نبودن مشتری
        /// </summary>
        public int CartFailedDeliveryTypeId { get; set; }

        /// <summary>
        /// تاریخ و زمان شروع تحویل روز
        /// </summary>
        public DateTime? DailyDeliveryStartOn { get; set; }

        /// <summary>
        /// تاریخ و زمان پایان تحویل روز
        /// </summary>
        public DateTime? DailyDeliveryEndOn { get; set; }

        /// <summary>
        /// تاریخ و زمان تحویل فردایی
        /// </summary>
        public DateTime? TomorrowDeliveryOn { get; set; }
    }
}
