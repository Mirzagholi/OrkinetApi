using Core.Common.Base;

namespace Core.Models.Parameter.Security.UserAddress
{
    public class GetUserAddressByIdParam : BaseParam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
