using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProviderPhoto
{
    public class AddProviderPhotoParam : BaseParam
    {
        public int ProviderId { get; set; }

        public int ProviderGalleryId { get; set; }
    }
}
