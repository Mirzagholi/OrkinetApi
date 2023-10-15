using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.PrivateValue
{
    public class UpdatePrivateValueStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه مقدار
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه ویژگی خصوصی
        /// </summary>
        public int PrivateAttributeId { get; set; }

        /// <summary>
        /// شناسه وضعیت
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
