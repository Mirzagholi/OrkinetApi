using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetLandingVipProductVm>> Sp_GetLandingVipProduct() => await _context.GetManyAsync<GetLandingVipProductVm>
            (
                "Business.sp_GetLandingVipProduct"
        );

    }

}
