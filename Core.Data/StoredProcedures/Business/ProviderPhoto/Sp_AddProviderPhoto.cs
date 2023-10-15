using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProviderPhotoVm> Sp_AddProviderPhoto(AddProviderPhotoParam parameters) => await _context.GetAsync<AddProviderPhotoVm>
                (
                    "Business.sp_AddProviderPhoto",
                    parameters
                );
    }
}
