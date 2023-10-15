using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Blog;
using Core.Models.ViewModel.Business.Blog;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<GetAllBlogInfoUiVm> Sp_GetAllBlogInfoUi(GetAllBlogInfoUiParam parameters) => await _context.GetAsync<GetAllBlogInfoUiVm>
                (
                    "Business.sp_GetAllBlogInfoUi",
                    parameters
        );
    }
}
