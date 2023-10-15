using System.Threading.Tasks;
using Core.Models.Parameter.Common.ParbadStorage;
using Core.Models.ViewModel.Common.ParbadStorage;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<GetTransactionByIdVm> Sp_GetTransactionById(GetTransactionByIdParam parameters) => await _context.GetAsync<GetTransactionByIdVm>
                (
                    "Parbad.sp_GetTransactionById",
                    parameters
                );
    }
}
