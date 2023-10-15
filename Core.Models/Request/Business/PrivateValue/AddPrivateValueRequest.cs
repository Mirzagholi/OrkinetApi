using Core.Common.Base;

namespace Core.Models.Request.Business.PrivateValue
{
    public class AddPrivateValueRequest : BaseRequest
    {
        /// <summary>
        /// شناسه ویژگی خصوصی
        /// </summary>
        public int PrivateAttributeId { get; set; }

        /// <summary>
        /// نام مقدار ویژگی خصوصی
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int? Order { get; set; }
    }
}
