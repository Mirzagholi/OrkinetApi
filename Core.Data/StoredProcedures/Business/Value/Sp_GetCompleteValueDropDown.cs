using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Value;
using Core.Models.ViewModel.Business.Value;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetCompleteValueDropDownVm>> Sp_GetCompleteValueDropDown() => await _context.GetManyAsync<GetCompleteValueDropDownVm>
            (
                "Business.sp_GetCompleteValueDropDown"
        );

    }

}
