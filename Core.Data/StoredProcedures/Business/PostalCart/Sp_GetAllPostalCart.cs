using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.PostalCart;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetAllPostalCartVm>> Sp_GetAllPostalCart() => await _context.GetManyAsync<GetAllPostalCartVm>
            (
                "Business.sp_GetAllPostalCart"
            );
    }
}
