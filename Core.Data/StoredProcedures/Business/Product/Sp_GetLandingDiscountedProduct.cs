using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetLandingDiscountedProductVm>> Sp_GetLandingDiscountedProduct() => await _context.GetManyAsync<GetLandingDiscountedProductVm>
            (
                "Business.sp_GetLandingDiscountedProduct"
        );

    }

}
