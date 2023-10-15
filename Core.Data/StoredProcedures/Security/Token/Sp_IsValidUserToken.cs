using Core.Models.Model.Security;
using Core.Models.Parameter.Security.Token;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<UserToken> Sp_IsValidUserToken(IsValidUserTokenParam parameters) => await _context.GetAsync<UserToken>
        (
                "Security.Sp_IsValidUserToken",
                parameters
        );

    }

}
