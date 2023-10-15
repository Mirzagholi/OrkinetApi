using System.Threading.Tasks;
using Core.Models.Parameter.Business.ProviderAbsorption;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_AddProviderAbsorption(AddProviderAbsorptionParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_AddProviderAbsorption",
                    parameters
                );
    }
}
