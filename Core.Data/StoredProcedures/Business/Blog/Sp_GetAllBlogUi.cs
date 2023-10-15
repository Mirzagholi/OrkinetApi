using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.ViewModel.Business.Blog;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<GetAllBlogUiVm>> Sp_GetAllBlogUi() => await _context.GetManyAsync<GetAllBlogUiVm>
                (
                    "Business.sp_GetAllBlogUi"
        );
    }
}
