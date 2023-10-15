using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.Value
{
    public class UpdateValueStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
