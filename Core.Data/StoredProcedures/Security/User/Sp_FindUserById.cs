using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<FindUserByIdVm> Sp_FindUserById(FindUserByIdParam parameters) => await _context.GetAsync<FindUserByIdVm>
        (
                "Security.Sp_FindUserById",
                parameters
        );

    }

}
