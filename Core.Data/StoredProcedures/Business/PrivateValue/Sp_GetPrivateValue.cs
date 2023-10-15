using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.PrivateValue;
using Core.Models.ViewModel.Business.PrivateValue;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetPrivateValueVm>> Sp_GetPrivateValue(GetPrivateValueParam parameters) => await _context.GetManyWithPagingAsync<GetPrivateValueVm>
            (
                "Business.sp_GetPrivateValue",
                parameters
        );

    }

}
