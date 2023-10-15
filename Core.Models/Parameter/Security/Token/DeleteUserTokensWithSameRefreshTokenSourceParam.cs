using Core.Common.Base;

namespace Core.Models.Parameter.Security.Token
{
    public class DeleteUserTokensWithSameRefreshTokenSourceParam : BaseParam
    {
        public string RefreshTokenIdHashSource { get; set; }
    }
}
