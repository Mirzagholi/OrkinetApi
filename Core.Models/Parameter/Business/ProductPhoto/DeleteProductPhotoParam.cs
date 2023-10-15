using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProductPhoto
{
    public class DeleteProductPhotoParam : BaseParam
    {
        public int ProductId { get; set; }
        public int ProviderGalleryId { get; set; }
        public int ProviderId { get; set; }
    }
}
