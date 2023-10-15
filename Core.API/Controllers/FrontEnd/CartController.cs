using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Request.Business.Cart;
using System.Threading.Tasks;
using System.Collections.Generic;
using Parbad;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/cart")]
    public class CartController : BaseController
    {
        #region Property

        private readonly ICartSrv _cartSrv;
        private readonly IOnlinePayment _onlinePayment;

        #endregion Property

        #region Constructor
        public CartController(
            ICartSrv cartSrv,
            IOnlinePayment onlinePayment)
        {
            _cartSrv = cartSrv;
            _onlinePayment = onlinePayment;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن آیتم ها به سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("addcart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddCart([FromBody] List<AddCartRequest> model)
        {
            return Ok(await _cartSrv.AddCartAsync(model));
        }

        /// <summary>
        /// افزودن آدرس محصول به سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("setcartuseraddress")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetCartUserAddress([FromBody] SetCartUserAddressRequest model)
        {
            return Ok(await _cartSrv.SetCartUserAddressAsync(model));
        }

        /// <summary>
        /// شروع استعلام سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("startinquirycart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> StartInquiryCart([FromBody] StartInquiryCartRequest model)
        {
            return Ok(await _cartSrv.StartInquiryCartAsync(model));
        }

        /// <summary>
        /// نمایش استعلام سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns> 
        [Authorize]
        [HttpPost("checkinquirycart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> CheckInquiryCart([FromBody] CheckInquiryCartRequest model)
        {
            return Ok(await _cartSrv.CheckInquiryCartAsync(model));
        }

        /// <summary>
        /// مشخص نمودن هزینه ارسال سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("setcartdeliveryprice")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetCartDeliveryPrice([FromBody] SetCartDeliveryPriceRequest model)
        {
            return Ok(await _cartSrv.SetCartDeliveryPriceAsync(model));
        }

        /// <summary>
        /// لغو استعلام
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("cancelinquirycart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> CancelInquiryCart([FromBody] CancelInquiryCartRequest model)
        {
            return Ok(await _cartSrv.CancelInquiryCartAsync(model));
        }

        /// <summary>
        /// افزودن اطلاعات تکمیلی سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("setcartinfo")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetCartInfo([FromBody] SetCartInfoRequest model)
        {
            return Ok(await _cartSrv.SetCartInfoAsync(model));
        }

        /// <summary>
        /// پرداخت سبد خرید
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpPost("paycart")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> PayCart([FromBody] PayCartRequest model)
        {
            return await _cartSrv.PayCartAsync(model);
        }

        /// <summary>
        /// بازگشت بانک
        /// </summary>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>       
        [AllowAnonymous]
        [HttpGet("bankverify"), HttpPost("bankverify")]
        [IgnoreAntiforgeryToken]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<IActionResult> BankVerify()
        {
            return await _cartSrv.BankVerifyAsync();
        }

        /// <summary>
        /// دریافت نتیجه بانک برای سبد خرید
        /// </summary>
        /// <param name="cartId">پارامتر های ورودی</param>
        /// <returns>شماره تراکنش بازگشت داده می شود</returns>       
        [Authorize]
        [HttpGet("getcartbankresponse")]
        public async Task<ActionResult> GetCartBankResponse(int cartId)
        {
            return Ok(await _cartSrv.GetCartBankResponseAsync(cartId));
        }

        /// <summary>
        /// دریافت تمام سفارشات کاربر
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست سفارشات بازگشت داده می شود</returns>       
        [Authorize]
        [HttpGet("getallusercompletecart")]
        public async Task<ActionResult> GetAllUserCompleteCart([FromQuery] GetAllUserCompleteCartRequest model)
        {
            return Ok(await _cartSrv.GetAllUserCompleteCartAsync(model));
        }

        /// <summary>
        /// دربافت اطلاعات تکمیلی سفارش
        /// </summary>
        /// <param name="cartId">شناسه سبد خرید</param>
        /// <returns>لیست اطلاعات تکمیلی بازگشت داده می شود</returns>
        [Authorize]
        [HttpGet("getusercompletecartinfo")]
        public async Task<ActionResult> GetUserCompleteCartInfo(int cartId)
        {
            return Ok(await _cartSrv.GetUserCompleteCartInfoAsync(cartId));
        }

        #endregion Methods
    }
}