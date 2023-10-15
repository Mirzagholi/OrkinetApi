using Core.Models.Model.Security;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task Sp_AddUserToken(UserToken parameters) => await _context.ExecuteAsync
        (
                "Security.Sp_AddUserToken",
                parameters
        );

    }

}
