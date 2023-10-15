using Core.Common.Base;

namespace Core.Models.Request.Security.User
{
    public class LogOutRequest : BaseRequest
    {
        /// <summary>
        /// ریفرش توکن
        /// </summary>
        public string RefreshToken { get; set; }

    }
}
