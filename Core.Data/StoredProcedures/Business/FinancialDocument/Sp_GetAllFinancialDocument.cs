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

        public async Task<BasePagingResult<GetAllFinancialDocumentVm>> Sp_GetAllFinancialDocument(GetAllFinancialDocumentParam parameters) => await _context.GetManyWithPagingAsync<GetAllFinancialDocumentVm>
                (
                    "Business.sp_GetAllFinancialDocument",
                    parameters
        );
    }
}
