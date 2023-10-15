using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<GetCartUserCoordinateVm> Sp_GetCartUserCoordinate(GetCartUserCoordinateParam parameters) => await _context.GetAsync<GetCartUserCoordinateVm>
                (
                    "Business.sp_GetCartUserCoordinate",
                    parameters
                );
    }
}
