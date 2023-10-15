using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllProviderCompleteCartVm>> Sp_GetAllProviderCompleteCart(GetAllProviderCompleteCartParam parameters) => await _context.GetManyWithPagingAsync<GetAllProviderCompleteCartVm>
                (
                    "Business.sp_GetAllProviderCompleteCart",
                    parameters
                );
    }
}
