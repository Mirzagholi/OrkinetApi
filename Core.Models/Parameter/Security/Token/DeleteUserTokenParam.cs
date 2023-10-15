using Core.Common.Base;

namespace Core.Models.Parameter.Security.Token
{
    public class DeleteUserTokenParam : BaseParam
    {
        public string RefreshTokenIdHash { get; set; }
    }
}
