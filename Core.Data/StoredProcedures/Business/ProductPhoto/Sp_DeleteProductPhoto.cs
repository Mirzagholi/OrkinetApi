using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<DeleteProductPhotoVm> Sp_DeleteProductPhoto(DeleteProductPhotoParam parameters) => await _context.GetAsync<DeleteProductPhotoVm>
                (
                    "Business.sp_DeleteProductPhoto",
                    parameters
                );
    }
}
