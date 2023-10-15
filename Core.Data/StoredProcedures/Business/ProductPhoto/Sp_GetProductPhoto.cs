using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProductPhoto;
using Core.Models.ViewModel.Business.ProductPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProductPhotoVm>> Sp_GetProductPhoto(GetProductPhotoParam parameters) => await _context.GetManyAsync<GetProductPhotoVm>
            (
                "Business.sp_GetProductPhoto",
                parameters
        );

    }

}
