using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class ResetPasswordRequest : BaseRequest
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// کد تایید
        /// </summary>
        public int ConfirmCode { get; set; }

        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string Password { get; set; }
    }
}
