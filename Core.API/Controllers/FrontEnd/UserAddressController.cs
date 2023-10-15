using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.ServiceContract.Security;
using Core.Common.Base.Controllers;
using Core.Models.Request.Security.UserAddress;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/useraddress")]
    public class UserAddressController : BaseController
    {
        #region Property

        private readonly IUserAddressSrv _userAddressSrv;

        #endregion Property

        #region Constructor
        public UserAddressController(IUserAddressSrv userAddressSrv)
        {
            _userAddressSrv = userAddressSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// نمایش آدرس ها 
        /// </summary>
        /// <returns>لیست آدرس ها بازگشت داده می شود</returns>
        [Authorize]
        [HttpGet("getalluseraddress")]
        public async Task<ActionResult> GetAllUserAddress()
        {
            return Ok(await _userAddressSrv.GetAllUserAddressAsync());
        }

        /// <summary>
        /// نمایش آدرس بر اساس شناسه 
        /// </summary>
        /// <returns>آدرس انتخابی بازگشت داده می شود</returns>
        //[Authorize]
        [Authorize]
        [HttpGet("getuseraddressbyid")]
        public async Task<ActionResult> GetUserAddressById([FromQuery] GetUserAddressByIdRequest model)
        {
            return Ok(await _userAddressSrv.GetUserAddressByIdAsync(model));
        }

        /// <summary>
        /// نمایش آدرس پیش فرش 
        /// </summary>
        /// <returns>آدرس پیش فرش بازگشت داده می شود</returns>
        //[Authorize]
        [Authorize]
        [HttpGet("getdefaultuseraddress")]
        public async Task<ActionResult> GetDefaultUserAddress()
        {
            return Ok(await _userAddressSrv.GetDefaultUserAddressAsync());
        }


        /// <summary>
        /// افزودن آدرس برای سید خرید 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        //[Authorize]
        [Authorize]
        [HttpPost("adduseraddress")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddUserAddress([FromBody] AddUserAddressRequest model)
        {
            return Ok(await _userAddressSrv.AddUserAddressAsync(model));
        }

        /// <summary>
        /// ویرایش آدرس برای سید خرید 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        //[Authorize]
        [Authorize]
        [HttpPost("updateuseraddress")]
        public async Task<ActionResult> UpdateUserAddress([FromBody] UpdateUserAddressRequest model)
        {
            return Ok(await _userAddressSrv.UpdateUserAddressAsync(model));
        }

        /// <summary>
        /// حذف آدرس برای سید خرید 
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        //[Authorize]
        [Authorize]
        [HttpPost("deleteuseraddress")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> DeleteUserAddress([FromBody] DeleteUserAddressRequest model)
        {
            return Ok(await _userAddressSrv.DeleteUserAddressAsync(model));
        }

        #endregion Methods
    }
}