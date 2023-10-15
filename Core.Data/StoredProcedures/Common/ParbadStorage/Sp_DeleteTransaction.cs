using System.Threading.Tasks;
using Core.Models.Parameter.Common.ParbadStorage;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task Sp_DeleteTransaction(DeleteTransactionParam parameters) => await _context.ExecuteAsync
                (
                    "Parbad.sp_DeleteTransaction",
                    parameters
                );
    }
}
