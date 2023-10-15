using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetExpensiveProductUiVm>> Sp_GetExpensiveProductUi(GetExpensiveProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetExpensiveProductUiVm>
            (
                "Business.sp_GetExpensiveProductUi",
                parameters
            );

    }

}
