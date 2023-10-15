using Core.Common.Base;

namespace Core.Models.Request.Business.Attribute
{
    /// <summary>
    /// مدل پارامتر های ورودی ثبت ویژگی
    /// </summary>
    public class AddAttributeRequest : BaseRequest
    {
        /// <summary>
        /// نام ویژگی
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ترتیب نمایش ویژگی 
        /// </summary>
        public int? Order { get; set; }
    }
}
