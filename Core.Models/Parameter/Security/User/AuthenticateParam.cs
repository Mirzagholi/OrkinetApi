using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class AuthenticateParam : BaseParam
    {
        public string Username { get; set; }
        public byte[] Password { get; set; }
        //public int CaptchaId { get; set; }
        //public string CaptchaValue { get; set; }
    }
}
