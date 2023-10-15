using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllProviderInquiryCartVm>> Sp_GetAllProviderInquiryCart(GetAllProviderInquiryCartParam parameters) => await _context.GetManyWithPagingAsync<GetAllProviderInquiryCartVm>
                (
                    "Business.sp_GetAllProviderInquiryCart",
                    parameters
        );
    }
}
