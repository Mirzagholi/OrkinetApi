using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProductDelivery;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/productdelivery")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductDeliveryController : BaseController
    {
        #region Property

        private readonly IProductDeliverySrv _productDeliverySrv;

        #endregion Property

        #region Constructor

        public ProductDeliveryController(IProductDeliverySrv productDeliverySrv)
        {
            _productDeliverySrv = productDeliverySrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن محدوده ارسال
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproductdelivery")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProductDelivery([FromBody] AddProductDeliveryRequest model)
        {
            return Ok(await _productDeliverySrv.AddProductDeliveryAsync(model));
        }

        /// <summary>
        /// دریافت تمام محدوده های ارسال
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محدوده ارسال بازگشت داده می شود</returns>

        [HttpGet("getproductdelivery")]
        public async Task<IActionResult> GetProductDelivery([FromQuery] GetProductDeliveryRequest model)
        {
            return Ok(await _productDeliverySrv.GetProductDeliveryAsync(model));
        }

        /// <summary>
        /// ویرایش محدوده ارسال
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproductdelivery")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductDelivery([FromBody] UpdateProductDeliveryRequest model)
        {
            return Ok(await _productDeliverySrv.UpdateProductDeliveryAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت محدوده ارسال
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateproductdeliverystatus")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProductDeliveryStatus([FromBody] UpdateProductDeliveryStatusRequest model)
        {
            return Ok(await _productDeliverySrv.UpdateProductDeliveryStatusAsync(model));
        }

        #endregion Methods
    }
}