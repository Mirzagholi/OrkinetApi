using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetValueVm>> Sp_GetValue(GetValueParam parameters) => await _context.GetManyWithPagingAsync<GetValueVm>
                (
                    "Business.sp_GetValue",
                    parameters
        );
    }
}
