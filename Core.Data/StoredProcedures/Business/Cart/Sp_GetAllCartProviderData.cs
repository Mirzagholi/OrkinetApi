using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetAllCartProviderDataVm>> Sp_GetAllCartProviderData(GetAllCartProviderDataParam parameters) => await _context.GetManyAsync<GetAllCartProviderDataVm>
                (
                    "Business.sp_GetAllCartProviderData",
                    parameters
                );
    }
}
