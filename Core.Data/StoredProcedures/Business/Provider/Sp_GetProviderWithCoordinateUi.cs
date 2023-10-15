using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetProviderWithCoordinateUiVm>> Sp_GetProviderWithCoordinateUi() => await _context.GetManyAsync<GetProviderWithCoordinateUiVm>
            (
                "Business.sp_GetProviderWithCoordinateUi"
        );

    }

}
