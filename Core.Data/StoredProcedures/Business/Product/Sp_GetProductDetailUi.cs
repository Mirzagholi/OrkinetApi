using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Product;
using Core.Models.ViewModel.Business.Product;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<BaseProductDetailResult<GetProductDetailUiVm>> Sp_GetProductDetailUi(GetProductDetailUiParam parameters) => await _context.GetManyProductDetailAsync<GetProductDetailUiVm>
            (
                "Business.sp_GetProductDetailUi",
                parameters
            );

    }

}
