using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/product")]
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
        /// افزودن محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproduct")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest model)
        {
            return Ok(await _productSrv.AddProductAsync(model));
        }

        /// <summary>
        /// دریافت محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getproduct")]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductRequest model)
        {
            return Ok(await _productSrv.GetProductAsync(model));
        }

        /// <summary>
        /// ویرایش محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه نوع نحویل ( 1 : ارسال روز | 2 : ارسال فردایی  )</remarks>
        [HttpPost("updateproduct")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest model)
        {
            return Ok(await _productSrv.UpdateProductAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>

        [HttpPost("updateproductstatus")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductStatus([FromBody] UpdateProductStatusRequest model)
        {
            return Ok(await _productSrv.UpdateProductStatusAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات برای باکس کشویی
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getproductdropdown")]
        public async Task<IActionResult> GetProductDropDown()
        {
            return Ok(await _productSrv.GetProductDropDownAsync());
        }

        /// <summary>
        /// دریافت محصول با شناسه
        /// </summary>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getproviderproductbyid")]
        public async Task<IActionResult> GetProviderProductById(int id)
        {
            return Ok(await _productSrv.GetProviderProductByIdAsync(id));
        }

        #endregion Methods
    }
}