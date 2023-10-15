using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetLandingEconomicProductVm>> Sp_GetLandingEconomicProduct() => await _context.GetManyAsync<GetLandingEconomicProductVm>
            (
                "Business.sp_GetLandingEconomicProduct"
        );

    }

}
