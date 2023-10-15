using Core.Common.Base;

namespace Core.Models.ViewModel.Business.ProviderGallery
{
    public class GetProviderGalleryVm : BaseDataResult
    {
        public int Id { get; set; }
        public int CdnFileId { get; set; }
        public string Path { get; set; }
    }
}
