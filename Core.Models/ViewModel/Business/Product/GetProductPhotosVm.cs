using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetProductPhotosVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int ProviderGalleryId { get; set; }
        public int CdnFileId { get; set; }
        public string Photo { get; set; }
    }
}
