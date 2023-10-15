using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderGallery;
using Core.Models.ViewModel.Business.ProviderGallery;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderGalleryVm> Sp_AddProviderGallery(AddProviderGalleryParam parameters) => await _context.GetAsync<AddProviderGalleryVm>
                (
                    "Business.sp_AddProviderGallery",
                    parameters
                );
    }
}
