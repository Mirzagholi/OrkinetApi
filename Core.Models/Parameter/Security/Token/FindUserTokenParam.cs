using Core.Common.Base;

namespace Core.Models.Parameter.Security.Token
{
    public class FindUserTokenParam : BaseParam
    {
        public string RefreshTokenIdHash { get; set; }
    }
}
