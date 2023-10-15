using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<CheckProductForCartVm>> Sp_CheckProductForCart(CheckProductForCartParam parameters) => await _context.GetManyAsync<CheckProductForCartVm>
            (
                "Business.sp_CheckProductForCart",
                parameters
            );

    }

}
