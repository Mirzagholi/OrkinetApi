using Core.Common.Base;

namespace Core.Models.Parameter.Security.Token
{
    public class IsValidUserTokenParam : BaseParam
    {
        public string AccessTokenHash { get; set; }
        public int UserId { get; set; }
    }
}
