using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class UserConfirmCodeRequest : BaseRequest
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }
        
    }
}
