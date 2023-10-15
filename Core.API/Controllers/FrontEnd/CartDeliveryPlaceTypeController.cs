using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using System.Threading.Tasks;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/cartdeliveryplacetype")]
    public class CartDeliveryPlaceTypeController : BaseController
    {
        #region Property

        private readonly ICartDeliveryPlaceTypeSrv _cartDeliveryPlaceTypeSrv;

        #endregion Property

        #region Constructor
        public CartDeliveryPlaceTypeController(ICartDeliveryPlaceTypeSrv cartDeliveryPlaceTypeSrv)
        {
            _cartDeliveryPlaceTypeSrv = cartDeliveryPlaceTypeSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمامی نوع محل ارسال سفارش
        /// </summary>
        /// <returns>لیست نوع محل ارسال بازگشت داده می شود</returns>
        [HttpGet("getallcartdeliveryplacetype")]
        public async Task<ActionResult> GetAllCartDeliveryPlaceType()
        {
            return Ok(await _cartDeliveryPlaceTypeSrv.GetAllCartDeliveryPlaceTypeAsync());
        }

        #endregion Methods
    }
}