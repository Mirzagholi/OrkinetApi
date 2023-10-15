using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product.GetProviderProductById
{
    public class GetProviderProductByIdPhotoVm : BaseDataResult
    {
        public int ProviderGalleryId { get; set; }
        public int CdnFileId { get; set; }
        public string Photo { get; set; }
    }
}
