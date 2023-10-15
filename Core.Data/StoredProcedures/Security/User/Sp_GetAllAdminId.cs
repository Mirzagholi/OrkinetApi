using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<IEnumerable<string>> Sp_GetAllAdminId() => await _context.GetManyAsync<string>
        (
                "Security.Sp_GetAllAdminId"
        );

    }

}
