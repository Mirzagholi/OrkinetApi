using System.Threading.Tasks;
using Core.Models.Parameter.Business.Category;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetCategoryByIdVm> Sp_GetCategoryById(GetCategoryByIdParam parameters) => await _context.GetAsync<GetCategoryByIdVm>
            (
                "Business.sp_GetCategoryById",
                parameters
            );

    }

}
