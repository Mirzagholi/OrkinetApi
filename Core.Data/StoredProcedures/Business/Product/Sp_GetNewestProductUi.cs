using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BasePagingResult<GetNewestProductUiVm>> Sp_GetNewestProductUi(GetNewestProductUiParam parameters) => await _context.GetManyWithPagingAsync<GetNewestProductUiVm>
            (
                "Business.sp_GetNewestProductUi",
                parameters
            );

    }

}
