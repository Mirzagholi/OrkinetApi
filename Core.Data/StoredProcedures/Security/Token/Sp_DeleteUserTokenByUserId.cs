using Core.Models.Model.Security;
using Core.Models.Parameter.Security.Token;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task Sp_DeleteUserTokenByUserId(DeleteUserTokenByUserIdParam parameters) => await _context.ExecuteAsync
        (
                "Security.Sp_DeleteUserTokenByUserId",
                parameters
        );

    }

}
