using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProviderPhoto
{
    public class DeleteProviderPhotoParam : BaseParam
    {
        public int ProviderId { get; set; }

        public int ProviderGalleryId { get; set; }
    }
}
