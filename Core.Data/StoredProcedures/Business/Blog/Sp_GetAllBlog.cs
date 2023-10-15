using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Blog;
using Core.Models.ViewModel.Business.Blog;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllBlogVm>> Sp_GetAllBlog(GetAllBlogParam parameters) => await _context.GetManyWithPagingAsync<GetAllBlogVm>
                (
                    "Business.sp_GetAllBlog",
                    parameters
        );
    }
}
