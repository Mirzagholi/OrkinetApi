using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [AllowAnonymous]
    [ApiController, Route("api/product")]
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
        /// دریافت لیست محصولات پر تخفیف برای صفحه لندینگ
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getlandingdiscountedproduct")]
        public async Task<ActionResult> GetLandingDiscountedProduct()
        {
            return Ok(await _productSrv.GetLandingDiscountedProductAsync());
        }

        /// <summary>
        /// دریافت لیست محصولات اقتصادی ترین برای صفحه لندینگ
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getlandingeconomicproduct")]
        public async Task<ActionResult> GetLandingEconomicProduct()
        {
            return Ok(await _productSrv.GetLandingEconomicProductAsync());
        }

        /// <summary>
        /// دریافت لیست محصولات پر فروش ترین برای صفحه لندینگ
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getlandingmostsalesproduct")]
        public async Task<ActionResult> GetLandingMostSalesProduct()
        {
            return Ok(await _productSrv.GetLandingMostSalesProductAsync());
        }

        /// <summary>
        /// دریافت لیست محصولات برتر برای صفحه لندینگ
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getlandingvipproduct")]
        public async Task<ActionResult> GetLandingVipProduct()
        {
            return Ok(await _productSrv.GetLandingVipProductAsync());
        }

        /// <summary>
        /// دریافت تمام محصولات برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getallproductui")]
        public async Task<ActionResult> GetAllProductUi([FromQuery] GetAllProductUiRequest model)
        {
            return Ok(await _productSrv.GetAllProductUiAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات تخفیف دار برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getdiscountedproductui")]
        public async Task<ActionResult> GetDiscountedProductUi([FromQuery] GetDiscountedProductUiRequest model)
        {
            return Ok(await _productSrv.GetDiscountedProductUiAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات جدید برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getnewestproductui")]
        public async Task<ActionResult> GetNewestProductUi([FromQuery] GetNewestProductUiRequest model)
        {
            return Ok(await _productSrv.GetNewestProductUiAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات گران قیمت برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getexpensiveproductui")]
        public async Task<ActionResult> GetExpensiveProductUi([FromQuery] GetExpensiveProductUiRequest model)
        {
            return Ok(await _productSrv.GetExpensiveProductUiAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات ارزان قیمت برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getcheapestproductui")]
        public async Task<ActionResult> GetCheapestProductUi([FromQuery] GetCheapestProductUiRequest model)
        {
            return Ok(await _productSrv.GetCheapestProductUiAsync(model));
        }

        /// <summary>
        /// دریافت محصول بر اساس شناسه
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>محصول انتخابی بازگشت داده می شود</returns>
        [HttpGet("getproductdetailui")]
        public async Task<ActionResult> GetProductDetailUi([FromQuery] GetProductDetailUiRequest model)
        {
            return Ok(await _productSrv.GetProductDetailUiAsync(model));
        }

        /// <summary>
        /// بررسی اینکه محصولات سید خرید تغییراتی داشتند
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>محصولاتی که تغییر داشتند را بازگشت داده می شود</returns>
        [HttpPost("checkproductforcart")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> CheckProductForCart([FromBody] List<CheckProductForCartRequest> model)
        {
            return Ok(await _productSrv.CheckProductForCartAsync(model));
        }


        /// <summary>
        /// دریافت تمام محصولات ارزان قیمت برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getfirstpageproductui")]
        public async Task<ActionResult> GetFirstPageProductUi([FromQuery] GetFirstPageProductUiRequest model)
        {
            return Ok(await _productSrv.GetFirstPageProductUiAsync(model));
        }


        #endregion Methods
    }
}