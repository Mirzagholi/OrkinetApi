using Core.Common.Base;

namespace Core.Models.Request.Business.Attribute
{
    /// <summary>
    /// مدل پارامتر های ورودی ثبت ویژگی عمومی
    /// </summary>
    public class UpdateAttributeRequest : BaseRequest
    {
        /// <summary>
        /// شناسه ویژگی
        /// </summary>
        public int Id { get; set; }

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
