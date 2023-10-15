using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddProductPhotoVm> Sp_AddProductPhoto(AddProductPhotoParam parameters) => await _context.GetAsync<AddProductPhotoVm>
                (
                    "Business.sp_AddProductPhoto",
                    parameters
                );
    }
}
