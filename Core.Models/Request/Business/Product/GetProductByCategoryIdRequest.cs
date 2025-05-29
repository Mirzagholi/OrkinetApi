using Core.Common.Base;

namespace Core.Models.Request.Business.Product
{
    public class GetProductByCategoryIdRequest : BaseRequest
    {
        /// <summary>
        /// شناسه دسته بندی
        /// </summary>
        public int CategoryId { get; set; }
    }
}
