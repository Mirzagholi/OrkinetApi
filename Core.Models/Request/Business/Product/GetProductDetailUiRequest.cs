using Core.Common.Base;

namespace Core.Models.Request.Business.Product
{
    public class GetProductDetailUiRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }
    }
}
