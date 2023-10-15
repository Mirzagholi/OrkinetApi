using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.ServiceContract.Security;
using Core.Common.Base.Controllers;
using Core.Models.Request.Security.User;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/account")]
    public class AccountController : BaseController
    {
        #region Property

        private readonly IUserSrv _userSrv;

        #endregion Property

        #region Constructor
        public AccountController(IUserSrv userSrv)
        {
            _userSrv = userSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// بررسی وضعیت ثبت نام 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>وضعیت ثبت نام مربوطه بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("loginorregister")]
        public async Task<ActionResult> LoginOrRegister([FromBody] LoginOrRegisterRequest model)
        {
            return Ok(await _userSrv.LoginOrRegisterAsync(model));
        }

        /// <summary>
        /// ثبت کلمه عبور 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>در صورت تایید توکن مربوطه بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("setpassword")]
        public async Task<ActionResult> SetPassword([FromBody] SetPasswordRequest model)
        {
            return Ok(await _userSrv.SetPasswordAsync(model));
        }

        /// <summary>
        /// احراز هویت کاربران سایت
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>در صورت تایید توکن مربوطه بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateRequest model)
        {
            return Ok(await _userSrv.AuthenticateAsync(model));
        }

        /// <summary>
        /// فعال سازی کاربران لندینگ
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>در صورت تایید توکن مربوطه بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("useractivation")]
        public async Task<ActionResult> UserActivation([FromBody] UserActivationRequest model)
        {
            return Ok(await _userSrv.UserActivationAsync(model));
        }

        /// <summary>
        /// دریافت اطلاعات کاربر احراز هویت شده
        /// </summary>
        /// <returns>اطلاعات کاربر بازگشت داده می شود</returns>
        [Authorize]
        [HttpGet("getuserinfo")]
        public async Task<ActionResult> GetUserInfo()
        {
            return Ok(await _userSrv.GetUserInfoAsync());
        }

        /// <summary>
        /// ارسال کد تایید به ایمیل یا موبایل
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("userconfirmcode")]
        public async Task<ActionResult> UserConfirmCode([FromBody] UserConfirmCodeRequest model)
        {
            return Ok(await _userSrv.UserConfirmCodeAsync(model));
        }

        /// <summary>
        /// تغییر کلمه عبور
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>        
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("resetpassword")]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            return Ok(await _userSrv.ResetPasswordAsync(model));
        }

        /// <summary>
        /// ویرایش کاربر احراز هویت شده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost("updateuser")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserRequest model)
        {
            return Ok(await _userSrv.UpdateUserAsync(model));
        }

        /// <summary>
        /// احراز هویت با استفاده از رفرش توکن 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>وضعیت ثبت نام مربوطه بازگشت داده می شود</returns>
        [AllowAnonymous]
        [IgnoreAntiforgeryToken]
        [HttpPost("signinviarefreshtoken")]
        public async Task<ActionResult> SignInViaRefreshToken([FromBody] SignInViaRefreshTokenRequest model)
        {
            return Ok(await _userSrv.SignInViaRefreshTokenAsync(model));
        }

        /// <summary>
        /// خروج کاربر
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [Authorize]
        [IgnoreAntiforgeryToken]
        [HttpPost("logout")]
        public async Task<ActionResult> Logout([FromBody] LogOutRequest model)
        {
            return Ok(await _userSrv.LogOutAsync(model));
        }

        #endregion Methods
    }
}