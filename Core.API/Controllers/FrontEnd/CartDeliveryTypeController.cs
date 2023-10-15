using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using System.Threading.Tasks;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/cartdeliverytype")]
    public class CartDeliveryTypeController : BaseController
    {
        #region Property

        private readonly ICartDeliveryTypeSrv _cartDeliveryTypeSrv;

        #endregion Property

        #region Constructor
        public CartDeliveryTypeController(ICartDeliveryTypeSrv cartDeliveryTypeSrv)
        {
            _cartDeliveryTypeSrv = cartDeliveryTypeSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمامی نوع ارسال سفارش
        /// </summary>
        /// <returns>لیست نوع ارسال بازگشت داده می شود</returns>
        [HttpGet("getallcartdeliverytype")]
        public async Task<ActionResult> GetAllCartDeliveryType()
        {
            return Ok(await _cartDeliveryTypeSrv.GetAllCartDeliveryTypeAsync());
        }

        #endregion Methods
    }
}