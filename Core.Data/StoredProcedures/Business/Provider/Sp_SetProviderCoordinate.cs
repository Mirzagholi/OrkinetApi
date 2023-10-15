using System.Threading.Tasks;
using Core.Models.Parameter.Business.Provider;
using Core.Models.ViewModel.Business.Provider;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<SetProviderCoordinateVm> Sp_SetProviderCoordinate(SetProviderCoordinateParam parameters) => await _context.GetAsync<SetProviderCoordinateVm>
                (
                    "Business.sp_SetProviderCoordinate",
                    parameters
                );
    }
}
