using Core.Common.Base;

namespace Core.Models.Parameter.Security.UserAddress
{
    public class DeleteUserAddressParam : BaseParam
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}
