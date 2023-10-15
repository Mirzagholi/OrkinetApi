using Core.Common.Base;

namespace Core.Models.ViewModel.Business.ProviderPhoto
{
    public class GetProviderPhotoVm : BaseDataResult
    {
        public int ProviderGalleryId { get; set; }

        public string Path { get; set; }

        public int CdnFileId { get; set; }
    }
}
