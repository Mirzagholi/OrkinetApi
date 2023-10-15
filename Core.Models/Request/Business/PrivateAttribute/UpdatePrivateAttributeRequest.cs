using Core.Common.Base;

namespace Core.Models.Request.Business.PrivateAttribute
{
    public class UpdatePrivateAttributeRequest : BaseRequest
    {
        /// <summary>
        /// شناسه ویژگی خصوصی
        /// </summary>
        public int Id { get; set; }

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
