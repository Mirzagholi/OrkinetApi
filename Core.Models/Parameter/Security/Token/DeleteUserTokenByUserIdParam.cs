using Core.Common.Base;

namespace Core.Models.Parameter.Security.Token
{
    public class DeleteUserTokenByUserIdParam : BaseParam
    {
        public int UserId { get; set; }
    }
}
