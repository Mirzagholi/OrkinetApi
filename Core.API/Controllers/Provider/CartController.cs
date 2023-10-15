using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Core.Models.Request.Business.Cart;
using System.Threading.Tasks;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/cart")]
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
        /// دریافت اطلاعات استعلام سبد خرید برای تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست سبد خرید بازگشت داده می شود</returns>
        [HttpGet("getallproviderinquirycart")]
        public async Task<ActionResult> GetAllProviderInquiryCart([FromQuery] GetAllProviderInquiryCartRequest model)
        {
            return Ok(await _cartSrv.GetAllProviderInquiryCartAsync(model));
        }

        /// <summary>
        /// تعیین وضعیت استعلام
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("setresultinquirycart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetResultInquiryCart([FromBody] SetResultInquiryCartRequest model)
        {
            return Ok(await _cartSrv.SetResultInquiryCartAsync(model));
        }

        /// <summary>
        /// دربافت اطلاعات تکمیلی استعلام
        /// </summary>
        /// <param name="cartId">شناسه سبد خرید</param>
        /// <returns>لیست اطلاعات تکمیلی بازگشت داده می شود</returns>
        [HttpGet("getproviderinquirycartinfo")]
        public async Task<ActionResult> GetProviderInquiryCartInfo(int cartId)
        {
            return Ok(await _cartSrv.GetProviderInquiryCartInfoAsync(cartId));
        }

        /// <summary>
        /// دریافت اطلاعات سبد خرید برای تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست سبد خرید بازگشت داده می شود</returns>
        [HttpGet("getallprovidercompletecart")]
        public async Task<ActionResult> GetAllProviderCompleteCart([FromQuery] GetAllProviderCompleteCartRequest model)
        {
            return Ok(await _cartSrv.GetAllProviderCompleteCartAsync(model));
        }

        /// <summary>
        /// دربافت اطلاعات تکمیلی سفارش
        /// </summary>
        /// <param name="cartId">شناسه سبد خرید</param>
        /// <returns>لیست اطلاعات تکمیلی بازگشت داده می شود</returns>
        [HttpGet("getprovidercompletecartinfo")]
        public async Task<ActionResult> GetProviderCompleteCartInfo(int cartId)
        {
            return Ok(await _cartSrv.GetProviderCompleteCartInfoAsync(cartId));
        }

        /// <summary>
        /// تعیین وضعیت سفارش
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("setprovidercartstatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetProviderCartStatus([FromBody] SetProviderCartStatusRequest model)
        {
            return Ok(await _cartSrv.SetProviderCartStatusAsync(model));
        }
        #endregion Methods
    }
}