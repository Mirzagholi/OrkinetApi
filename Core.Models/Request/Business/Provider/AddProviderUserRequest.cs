using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class AddProviderUserRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// نام کاربری
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// کلمه عبور
        /// </summary>
        public string Password { get; set; }
    }
}
