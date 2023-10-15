using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProductDiscount;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/productdiscount")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductDiscountController : BaseController
    {
        #region Property

        private readonly IProductDiscountSrv _productDiscountSrv;

        #endregion Property

        #region Constructor

        public ProductDiscountController(IProductDiscountSrv productDiscountSrv)
        {
            _productDiscountSrv = productDiscountSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن تخفیف محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproductdiscount")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProductDiscount([FromBody] AddProductDiscountRequest model)
        {
            return Ok(await _productDiscountSrv.AddProductDiscountAsync(model));
        }

        /// <summary>
        /// دریافت تمام تخفیف های محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تخفیف ها بازگشت داده می شود</returns>
        [HttpGet("getproductdiscount")]
        public async Task<IActionResult> GetProductDiscount([FromQuery] GetProductDiscountRequest model)
        {
            return Ok(await _productDiscountSrv.GetProductDiscountAsync(model));
        }

        /// <summary>
        /// ویرایش تخفیف محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproductdiscount")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductDiscount([FromBody] UpdateProductDiscountRequest model)
        {
            return Ok(await _productDiscountSrv.UpdateProductDiscountAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت تخفیف محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateproductdiscountstatus")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductDiscountStatus([FromBody] UpdateProductDiscountStatusRequest model)
        {
            return Ok(await _productDiscountSrv.UpdateProductDiscountStatusAsync(model));
        }

        #endregion Methods
    }
}