using Core.Common.Base;

namespace Core.Models.Parameter.Security.User
{
    public class LoginOrRegisterParam : BaseParam
    {
        /// <summary>
        /// شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
