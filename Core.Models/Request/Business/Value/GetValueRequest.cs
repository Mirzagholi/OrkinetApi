using Core.Common.Base;

namespace Core.Models.Request.Business.Value
{
    public class GetValueRequest : BasePagingRequest
    {
        /// <summary>
        /// شناسه ویژگی عمومی
        /// </summary>
        public int AttributeId { get; set; }
    }
}
