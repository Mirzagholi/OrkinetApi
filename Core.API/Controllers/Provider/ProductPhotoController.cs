using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.Models.Request.Business.ProductPhoto;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/productphoto")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductPhotoController : BaseController
    {
        #region Property

        private readonly IProductPhotoSrv _productPhotoSrv;

        #endregion Property

        #region Constructor

        public ProductPhotoController(IProductPhotoSrv productPhotoSrv)
        {
            _productPhotoSrv = productPhotoSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// اتصال تصویر به محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproductphoto")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProductPhoto([FromBody] AddProductPhotoRequest model)
        {
            return Ok(await _productPhotoSrv.AddProductPhotoAsync(model));
        }

        /// <summary>
        /// دریافت تمام تصاویر محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تصاویر محصولات بازگشت داده می شود</returns>
        [HttpGet("getproductphoto")]
        public async Task<IActionResult> GetProductPhoto([FromQuery] GetProductPhotoRequest model)
        {
            return Ok(await _productPhotoSrv.GetProductPhotoAsync(model));
        }

        /// <summary>
        /// حذف اتصال تصویر به محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("deleteproductphoto")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteProductPhoto([FromBody] DeleteProductPhotoRequest model)
        {
            return Ok(await _productPhotoSrv.DeleteProductPhotoAsync(model));
        }

        #endregion Methods
    }
}