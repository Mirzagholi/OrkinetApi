using System.Collections.Generic;
using System.Threading.Tasks;
using Parbad.Storage.Abstractions.Models;

namespace Core.Data.Repository
{
    public partial class Repository
    {

        public async Task<IEnumerable<Payment>> Sp_GetAllPayment() => await _context.GetManyAsync<Payment>
                (
                    "Parbad.sp_GetAllPayment"
                );
    }
}
