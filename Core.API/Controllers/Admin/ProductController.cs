using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Attribute;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.Product;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/product")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductController : BaseController
    {
        #region Property

        private readonly IProductSrv _productSrv;

        #endregion Property

        #region Constructor
        public ProductController(IProductSrv productSrv)
        {
            _productSrv = productSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت محصولات برای ادمین
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getallproductforadmin")]
        public async Task<IActionResult> GetAllProductForAdmin([FromQuery] GetAllProductForAdminRequest model)
        {
            return Ok(await _productSrv.GetAllProductForAdminAsync(model));
        }

        /// <summary>
        /// تایید محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("confirmproduct")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> ConfirmProduct([FromBody] ConfirmProductRequest model)
        {
            return Ok(await _productSrv.ConfirmProductAsync(model));
        }

        #endregion Methods
    }
}