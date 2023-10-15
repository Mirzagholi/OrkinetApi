using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetLandingMostSalesProductVm>> Sp_GetLandingMostSalesProduct() => await _context.GetManyAsync<GetLandingMostSalesProductVm>
            (
                "Business.sp_GetLandingMostSalesProduct"
        );

    }

}
