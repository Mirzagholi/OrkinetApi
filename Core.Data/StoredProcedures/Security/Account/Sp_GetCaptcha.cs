using Core.Models.ViewModel.Security.Captcha;
using System.Threading.Tasks;

namespace Core.Data.Repository
{
    public partial class Repository
    {
        public async Task<GetCaptchaVm> Sp_GetCaptcha()
        {
            return await _context.GetAsync<GetCaptchaVm>("Security.sp_GetCaptcha");
        }
    }
}
