using System.Threading.Tasks;
using Core.Models.Parameter.Business.Category;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<AddCategoryVm> Sp_AddCategory(AddCategoryParam parameters) => await _context.GetAsync<AddCategoryVm>
                (
                    "Business.sp_AddCategory",
                    parameters
                );
    }
}
