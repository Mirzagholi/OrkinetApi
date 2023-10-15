using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class ProviderAuthenticateRequest : BaseRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
