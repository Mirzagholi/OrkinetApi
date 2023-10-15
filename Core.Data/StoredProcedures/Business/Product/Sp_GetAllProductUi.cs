using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetAllProductUiVm>> Sp_GetAllProductUi(GetAllProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetAllProductUiVm>
            (
                "Business.sp_GetAllProductUi",
                parameters
            );

    }

}
