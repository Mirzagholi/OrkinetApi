using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class SetPasswordParam : BaseParam
    {
        public string Username { get; set; }
        public byte[] Password { get; set; }
    }
}
