using System.Threading.Tasks;
using Core.Models.Parameter.Common.ParbadStorage;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_UpdateTransaction(UpdateTransactionParam parameters) => await _context.ExecuteAsync
                (
                    "Parbad.sp_UpdateTransaction",
                    parameters
                );
    }
}
