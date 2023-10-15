using System.Threading.Tasks;
using Core.Models.Parameter.Common.ParbadStorage;
using Core.Models.ViewModel.Common.ParbadStorage;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<GetPaymentByIdVm> Sp_GetPaymentById(GetPaymentByIdParam parameters) => await _context.GetAsync<GetPaymentByIdVm>
                (
                    "Parbad.sp_GetPaymentById",
                    parameters
                );
    }
}
