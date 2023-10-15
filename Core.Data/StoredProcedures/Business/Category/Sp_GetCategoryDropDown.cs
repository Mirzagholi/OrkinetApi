using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<GetCategoryDropDownVm>> Sp_GetCategoryDropDown() => await _context.GetManyAsync<GetCategoryDropDownVm>
            (
                "Business.sp_GetCategoryDropDown"
        );

    }

}
