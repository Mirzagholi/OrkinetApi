using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.ProductDelivery
{
    public class UpdateProductDeliveryStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محدوده ارسال
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
