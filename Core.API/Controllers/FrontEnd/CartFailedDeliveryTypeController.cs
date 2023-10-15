using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using System.Threading.Tasks;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/cartfaileddeliverytype")]
    public class CartFailedDeliveryTypeController : BaseController
    {
        #region Property

        private readonly ICartFailedDeliveryTypeSrv _cartFailedDeliveryTypeSrv;

        #endregion Property

        #region Constructor
        public CartFailedDeliveryTypeController(ICartFailedDeliveryTypeSrv cartFailedDeliveryTypeSrv)
        {
            _cartFailedDeliveryTypeSrv = cartFailedDeliveryTypeSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمامی حالات نبودن مشتری سفارش
        /// </summary>
        /// <returns>لیست حالات نبودن مشتری بازگشت داده می شود</returns>
        [HttpGet("getallcartfaileddeliverytype")]
        public async Task<ActionResult> GetAllCartFailedDeliveryType()
        {
            return Ok(await _cartFailedDeliveryTypeSrv.GetAllCartFailedDeliveryTypeAsync());
        }

        #endregion Methods
    }
}