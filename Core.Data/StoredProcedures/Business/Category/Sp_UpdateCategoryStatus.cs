using System.Threading.Tasks;
using Core.Models.Parameter.Business.Category;
using Core.Models.ViewModel.Business.Category;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<UpdateCategoryStatusVm> Sp_UpdateCategoryStatus(UpdateCategoryStatusParam parameters) => await _context.GetAsync<UpdateCategoryStatusVm>
                (
                    "Business.sp_UpdateCategoryStatus",
                    parameters
                );
    }
}
