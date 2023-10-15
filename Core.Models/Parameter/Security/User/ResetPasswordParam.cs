using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class ResetPasswordParam : BaseParam
    {
        public string Username { get; set; }
        public int ConfirmCode { get; set; }
        public byte[] Password { get; set; }
    }
}
