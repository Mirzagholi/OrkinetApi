using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Request.Business.Product
{
    public class GetFirstPageProductUiRequest : BaseRequest
    {
        /// <summary>
        /// شناسه دسته
        /// </summary>
        public int? CategoryId { get; set; }


        public ProductListType ProductListTypeId { get; set; }

        /// <summary>
        /// تعداد رکورد ها جهت نمایش
        /// </summary>
        public int? PageRecord { get; set; }
    }


    public class GetFirstPageCategoryUiRequest : BaseRequest
    {
        /// <summary>
        /// شناسه دسته
        /// </summary>
        public int? ParentCategoryId { get; set; }


        /// <summary>
        /// تعداد رکورد ها جهت نمایش
        /// </summary>
        public int? PageRecord { get; set; }
    }
}
