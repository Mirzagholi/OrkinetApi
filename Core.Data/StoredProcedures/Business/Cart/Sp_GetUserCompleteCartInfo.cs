using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseCartInfoResult<GetUserCompleteCartProductVm, GetUserCompleteCartInfoVm>>
            Sp_GetUserCompleteCartInfo(GetUserCompleteCartInfoParam parameters) => 
            await _context.GetManyCartInfoAsync<GetUserCompleteCartProductVm, GetUserCompleteCartInfoVm>
            (
                "Business.sp_GetUserCompleteCartInfo",
                parameters
            );

    }

}
