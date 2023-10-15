using Core.Common.Base;

namespace Core.Models.Request.Business.Value
{
    public class AddValueRequest : BaseRequest
    {
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شناسه ویژگی عمومی
        /// </summary>
        public int AttributeId { get; set; }

        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int? Order { get; set; }
    }
}
