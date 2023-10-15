using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetCartProviderCoordinateVm>> Sp_GetCartProviderCoordinate(GetCartProviderCoordinateParam parameters) => await _context.GetManyAsync<GetCartProviderCoordinateVm>
                (
                    "Business.sp_GetCartProviderCoordinate",
                    parameters
                );
    }
}
