using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.ProductDiscount
{
    public class UpdateProductDiscountStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تخفیف
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
