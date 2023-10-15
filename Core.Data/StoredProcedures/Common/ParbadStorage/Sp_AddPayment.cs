using System.Threading.Tasks;
using Core.Models.Parameter.Common.ParbadStorage;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<int> Sp_AddPayment(AddPaymentParam parameters) => await _context.GetAsync<int>
                (
                    "Parbad.sp_AddPayment",
                    parameters
                );
    }
}
