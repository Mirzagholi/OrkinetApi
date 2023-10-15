using System.Threading.Tasks;
using Core.Models.Parameter.Business.Blog;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_AddBlog(AddBlogParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_AddBlog",
                    parameters
                );
    }
}
