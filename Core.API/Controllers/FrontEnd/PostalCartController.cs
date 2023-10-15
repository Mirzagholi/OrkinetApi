using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using System.Threading.Tasks;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/postalcart")]
    public class PostalCartController : BaseController
    {
        #region Property

        private readonly IPostalCartSrv _postalCartSrv;

        #endregion Property

        #region Constructor
        public PostalCartController(IPostalCartSrv postalCartSrv)
        {
            _postalCartSrv = postalCartSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمامی کارت پستال های فعال
        /// </summary>
        /// <returns>لیست کارت پستال ها بازگشت داده می شود</returns>
        [HttpGet("getallpostalcart")]
        public async Task<ActionResult> GetAllPostalCart()
        {
            return Ok(await _postalCartSrv.GetAllPostalCartAsync());
        }

        #endregion Methods
    }
}