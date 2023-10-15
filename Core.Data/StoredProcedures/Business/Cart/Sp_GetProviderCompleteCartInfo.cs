using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseCartInfoResult<GetProviderCompleteCartProductVm, GetProviderCompleteCartInfoVm>>
            Sp_GetProviderCompleteCartInfo(GetProviderCompleteCartInfoParam parameters) => 
            await _context.GetManyCartInfoAsync<GetProviderCompleteCartProductVm, GetProviderCompleteCartInfoVm>
            (
                "Business.sp_GetProviderCompleteCartInfo",
                parameters
            );

    }

}
