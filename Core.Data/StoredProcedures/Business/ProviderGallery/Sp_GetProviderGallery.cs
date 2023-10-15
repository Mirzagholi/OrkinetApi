using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderGallery;
using Core.Models.ViewModel.Business.ProviderGallery;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProviderGalleryVm>> Sp_GetProviderGallery(GetProviderGalleryParam parameters) => await _context.GetManyAsync<GetProviderGalleryVm>
            (
                "Business.sp_GetProviderGallery",
                parameters
        );

    }

}
