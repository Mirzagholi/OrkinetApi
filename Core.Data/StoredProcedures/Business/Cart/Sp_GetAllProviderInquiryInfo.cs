using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseCartInfoResult<GetProviderInquiryCartProductVm, GetProviderInquiryCartInfoVm>>
            Sp_GetProviderInquiryCartInfo(GetProviderInquiryCartInfoParam parameters) => 
            await _context.GetManyCartInfoAsync<GetProviderInquiryCartProductVm, GetProviderInquiryCartInfoVm>
            (
                "Business.sp_GetProviderInquiryCartInfo",
                parameters
            );

    }

}
