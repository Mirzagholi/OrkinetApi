using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteProviderPhotoVm> Sp_DeleteProviderPhoto(DeleteProviderPhotoParam parameters) => await _context.GetAsync<DeleteProviderPhotoVm>
                (
                    "Business.sp_DeleteProviderPhoto",
                    parameters
                );
    }
}
