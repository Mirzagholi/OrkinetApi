using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetCategoryVm>> Sp_GetCategory() => await _context.GetManyAsync<GetCategoryVm>
                (
                    "Business.sp_GetCategory"
        );

        public async Task<IEnumerable<GetCategoryVm>> Sp_GetCategoryInFirstPage() => await _context.GetManyAsync<GetCategoryVm>
               (
                   "Business.sp_GetCategoryInFirstPage"
       );
    }
}
