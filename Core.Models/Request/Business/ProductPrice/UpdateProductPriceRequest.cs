using Core.Common.Base;

namespace Core.Models.Request.Business.ProductPrice
{
    public class UpdateProductPriceRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public int Price { get; set; }
    }
}
