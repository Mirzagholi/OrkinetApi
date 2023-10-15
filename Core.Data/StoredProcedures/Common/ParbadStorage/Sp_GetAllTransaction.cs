using System.Collections.Generic;
using System.Threading.Tasks;
using Parbad.Storage.Abstractions.Models;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<Transaction>> Sp_GetAllTransaction() => await _context.GetManyAsync<Transaction>
                (
                    "Parbad.sp_GetAllTransaction"
                );
    }
}
