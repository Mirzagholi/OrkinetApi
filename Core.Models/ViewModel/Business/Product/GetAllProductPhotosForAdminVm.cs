using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Product
{
    public class GetAllProductPhotosForAdminVm : BaseDataResult
    {
        public int ProductId { get; set; }
        public int ProviderGalleryId { get; set; }
    }
}
