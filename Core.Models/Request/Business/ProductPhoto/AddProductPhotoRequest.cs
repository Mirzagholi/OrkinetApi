using Core.Common.Base;

namespace Core.Models.Request.Business.ProductPhoto
{
    public class AddProductPhotoRequest : BaseRequest
    {

        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// شناسه تصویر گالری تصاویر
        /// </summary>
        public int ProviderGalleryId { get; set; }
    }
}
