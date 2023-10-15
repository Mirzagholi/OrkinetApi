using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.Attribute
{
    /// <summary>
    /// مدل پارامتر های  ورودی تغییر وضعیت ویژگی عمومی 
    /// </summary>
    public class UpdateAttributeStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه ویژگی عمومی
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت ویژگی عمومی
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
