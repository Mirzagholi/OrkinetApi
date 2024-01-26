using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.Parameter.Business.Category;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetCategoryVm>> Sp_GetCategory() => await _context.GetManyAsync<GetCategoryVm>
                (
                    "Business.sp_GetCategory"
        );

        public async Task<IEnumerable<GetCategoryVm>> Sp_GetCategoryInFirstPage(GetCategoryInFirstPageParam parameters) => await _context.GetManyAsync<GetCategoryVm>
               (
                   "Business.sp_GetCategoryInFirstPage",
                   parameters
       );
    }
}
