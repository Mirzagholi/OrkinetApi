using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Request.Business.Product
{
    public class UpdateProductRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شناسه دسته
        /// </summary>
        public string[] CategoryIdes { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// مقادیر عمومی
        /// </summary>
        public string[] Values { get; set; }

        /// <summary>
        /// مقادیر خصوصی
        /// </summary>
        public string[] PrivateValues { get; set; }

        /// <summary>
        /// شناسه نوع محصول
        /// </summary>
        public PreparationType PreparationTypeId { get; set; }

        /// <summary>
        /// توضیح کوتاه
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// توضیح بلند
        /// </summary>
        public string Description { get; set; }
    }
}
