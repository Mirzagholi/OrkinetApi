using Core.Models.Parameter.Security.Token;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task Sp_DeleteUserTokensWithSameRefreshTokenSource(DeleteUserTokensWithSameRefreshTokenSourceParam parameters) => await _context.ExecuteAsync
        (
            "Security.sp_DeleteUserTokensWithSameRefreshTokenSource",
            parameters
        );

    }

}
