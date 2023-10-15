using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class UserActivationRequest : BaseRequest
    {
        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// تایید کد تایید
        /// </summary>
        public int ConfirmCode { get; set; }
    }
}
