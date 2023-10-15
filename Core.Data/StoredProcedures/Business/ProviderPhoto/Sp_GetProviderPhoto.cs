using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderPhoto;
using Core.Models.ViewModel.Business.ProviderPhoto;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProviderPhotoVm>> Sp_GetProviderPhoto(GetProviderPhotoParam parameters) => await _context.GetManyAsync<GetProviderPhotoVm>
            (
                "Business.sp_GetProviderPhoto",
                parameters
        );

    }

}
