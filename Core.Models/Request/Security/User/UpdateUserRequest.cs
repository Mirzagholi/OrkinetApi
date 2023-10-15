using Core.Common.Base;
using Core.Models.Enum.Security;

namespace Core.Models.Request.Security.User
{
    public class UpdateUserRequest : BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType? GenderTypeId { get; set; }
        //public string Avatar { get; set; }
        //public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
