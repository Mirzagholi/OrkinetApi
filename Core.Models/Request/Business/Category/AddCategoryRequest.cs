using Core.Common.Base;

namespace Core.Models.Request.Business.Category
{
    public class AddCategoryRequest : BaseRequest
    {
        /// <summary>
        /// نام دسته
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شناسه پدر
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// ترتیب
        /// </summary>
        public int? Order { get; set; }

        /// <summary>
        /// کد آیکن
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
