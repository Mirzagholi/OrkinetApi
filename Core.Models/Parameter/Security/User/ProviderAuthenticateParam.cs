using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class ProviderAuthenticateParam : BaseParam
    {
        public string Username { get; set; }
        public byte[] Password { get; set; }
    }
}
