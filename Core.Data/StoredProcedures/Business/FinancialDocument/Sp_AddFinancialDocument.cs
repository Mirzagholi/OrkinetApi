using System.Threading.Tasks;
using Core.Models.Parameter.Business.Cart;
using Core.Models.Parameter.Business.FinancialDocument;
using Core.Models.ViewModel.Business.Cart;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_AddFinancialDocument(AddFinancialDocumentParam parameters) => await _context.ExecuteAsync
                (
                    "Business.sp_AddFinancialDocument",
                    parameters
                );
    }
}
