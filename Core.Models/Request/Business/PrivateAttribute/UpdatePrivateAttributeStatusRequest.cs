using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.PrivateAttribute
{
    public class UpdatePrivateAttributeStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه ویژگی خصوصی
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت ویژگی خصوصی
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
