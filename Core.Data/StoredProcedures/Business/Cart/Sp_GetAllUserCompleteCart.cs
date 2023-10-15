using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllUserCompleteCartVm>> Sp_GetAllUserCompleteCart(GetAllUserCompleteCartParam parameters) => await _context.GetManyWithPagingAsync<GetAllUserCompleteCartVm>
                (
                    "Business.sp_GetAllUserCompleteCart",
                    parameters
                );
    }
}
