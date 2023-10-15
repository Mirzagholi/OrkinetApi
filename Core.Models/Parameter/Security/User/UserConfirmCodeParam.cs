using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class UserConfirmCodeParam : BaseParam
    {
        public string Username { get; set; }
        public int ConfirmCode { get; set; }
    }
}
