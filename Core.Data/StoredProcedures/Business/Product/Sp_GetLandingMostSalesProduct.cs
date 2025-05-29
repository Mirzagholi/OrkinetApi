using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Request.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetLandingMostSalesProductVm>> Sp_GetLandingMostSalesProduct(GetProductByCategoryIdRequest parameters) => await _context.GetManyAsync<GetLandingMostSalesProductVm>
            (
                "Business.sp_GetLandingMostSalesProduct", parameters
        );

    }

}
