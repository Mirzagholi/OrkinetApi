using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class SetPasswordRequest : BaseRequest
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// تایید کلمه عبور
        /// </summary>
        public string RePassword { get; set; }
    }
}
