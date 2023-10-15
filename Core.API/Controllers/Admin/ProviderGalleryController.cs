using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProviderGallery;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/providergallery")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProviderGalleryController : BaseController
    {
        #region Property

        private readonly IProviderGallerySrv _providerGallerySrv;

        #endregion Property

        #region Constructor
        public ProviderGalleryController(IProviderGallerySrv providerGallerySrv)
        {
            _providerGallerySrv = providerGallerySrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن تصویر به گالری تصاویر تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprovidergallery")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddProviderGallery([FromForm] AddProviderGalleryRequest model)
        {
            return Ok(await _providerGallerySrv.AddProviderGalleryAsync(model));
        }

        /// <summary>
        /// دریافت تمام تصاویر گالری تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست گالری تصاویر بازگشت داده می شود</returns>
        [HttpGet("getprovidergallery")]
        public async Task<ActionResult> GetProviderGallery([FromQuery] GetProviderGalleryRequest model)
        {
            return Ok(await _providerGallerySrv.GetProviderGalleryAsync(model));
        }

        /// <summary>
        /// ویرایش وضعیت تصویر گالری تصاویر تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateprovidergallerystatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateProviderGalleryStatus([FromBody] UpdateProviderGalleryStatusRequest model)
        {
            return Ok(await _providerGallerySrv.UpdateProviderGalleryStatusAsync(model));
        }

        #endregion Methods
    }
}

