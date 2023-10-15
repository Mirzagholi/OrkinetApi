using Core.Common.Base;

namespace Core.Models.Request.Business.PrivateAttribute
{
    public class AddPrivateAttributeRequest : BaseRequest
    {
        /// <summary>
        /// نام ویژگی خصوصی
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ترتیب نمایش
        /// </summary>
        public int? Order { get; set; }
    }
}
