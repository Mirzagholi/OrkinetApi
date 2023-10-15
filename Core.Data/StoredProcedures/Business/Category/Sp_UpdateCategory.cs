using System.Threading.Tasks;
using Core.Models.Parameter.Business.Category;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateCategoryVm> Sp_UpdateCategory(UpdateCategoryParam parameters) => await _context.GetAsync<UpdateCategoryVm>
                (
                    "Business.sp_UpdateCategory",
                    parameters
                );
    }
}
