using System.Threading.Tasks;
using Core.Models.Parameter.Security.User;
using Core.Models.ViewModel.Security.User;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetUserInfoVm> Sp_GetUserInfo(GetUserInfoParam parameters) => await _context.GetAsync<GetUserInfoVm>
            (
                "Security.sp_GetUserInfo",
                parameters
            );

    }

}
