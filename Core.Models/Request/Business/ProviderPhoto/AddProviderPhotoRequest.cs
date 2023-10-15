using Core.Common.Base;

namespace Core.Models.Request.Business.ProviderPhoto
{
    public class AddProviderPhotoRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// شناسه تصویر گالری تصاویر
        /// </summary>
        public int ProviderGalleryId { get; set; }
    }
}
