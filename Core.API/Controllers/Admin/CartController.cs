using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Request.Business.Cart;
using System.Threading.Tasks;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/cart")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CartController : BaseController
    {
        #region Property

        private readonly ICartSrv _cartSrv;

        #endregion Property

        #region Constructor
        public CartController(ICartSrv cartSrv)
        {
            _cartSrv = cartSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت اطلاعات استعلام سبد خرید برای ادمین
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست ویژگی های خصوصی بازگشت داده می شود</returns>
        [HttpGet("getallactiveinquirycart")]
        public async Task<ActionResult> GetAllActiveInquiryCart([FromQuery] GetAllActiveInquiryCartRequest model)
        {
            return Ok(await _cartSrv.GetAllActiveInquiryCartAsync(model));
        }

        #endregion Methods
    }
}