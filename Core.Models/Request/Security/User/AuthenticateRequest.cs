using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class AuthenticateRequest:BaseRequest
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string Password { get; set; }

        ///// <summary>
        ///// شناسه کپتچا
        ///// </summary>
        //public int CaptchaId { get; set; }

        ///// <summary>
        ///// مقدار کپتچا
        ///// </summary>
        //public string CaptchaValue { get; set; }
    }
}
