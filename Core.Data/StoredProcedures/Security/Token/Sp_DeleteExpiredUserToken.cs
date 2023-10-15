using Core.Models.Parameter.Security.User;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task Sp_DeleteExpiredUserToken() => await _context.ExecuteAsync
        (
                "Security.sp_DeleteExpiredUserToken"
        );

    }

}
