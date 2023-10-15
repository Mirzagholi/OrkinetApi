using System.Threading.Tasks;
using Core.Common.Base;
using Core.Models.Parameter.Business.Cart;
using Core.Models.Parameter.Business.FinancialDocument;
using Core.Models.ViewModel.Business.Cart;
using Core.Models.ViewModel.Business.FinancialDocument;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<BasePagingResult<GetAllFinancialDocumentInfoVm>> Sp_GetAllFinancialDocumentInfo(GetAllFinancialDocumentInfoParam parameters) => await _context.GetManyWithPagingAsync<GetAllFinancialDocumentInfoVm>
                (
                    "Business.sp_GetAllFinancialDocumentInfo",
                    parameters
        );
    }
}
