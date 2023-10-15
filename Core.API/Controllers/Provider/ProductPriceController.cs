using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.Models.Request.Business.ProductPrice;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/productprice")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductPriceController : BaseController
    {
        #region Property

        private readonly IProductPriceSrv _productPriceSrv;

        #endregion Property

        #region Constructor

        public ProductPriceController(IProductPriceSrv productPriceSrv)
        {
            _productPriceSrv = productPriceSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// ثبت جدید قیمت محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproductprice")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductPrice([FromBody] UpdateProductPriceRequest model)
        {
            return Ok(await _productPriceSrv.UpdateProductPriceAsync(model));
        }

        #endregion Methods
    }
}