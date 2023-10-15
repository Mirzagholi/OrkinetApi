using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class LoginOrRegisterRequest : BaseRequest
    {
        /// <summary>
        /// شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
