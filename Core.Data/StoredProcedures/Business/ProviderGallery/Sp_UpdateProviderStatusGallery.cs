using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderGallery;
using Core.Models.ViewModel.Business.ProviderGallery;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateProviderGalleryStatusVm> Sp_UpdateProviderGalleryStatus(UpdateProviderGalleryStatusParam parameters) => await _context.GetAsync<UpdateProviderGalleryStatusVm>
                (
                    "Business.sp_UpdateProviderGalleryStatus",
                    parameters
                );
    }
}
