using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProviderPhoto;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/providerphoto")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProviderPhotoController : BaseController
    {
        #region Property

        private readonly IProviderPhotoSrv _ProviderPhotoSrv;

        #endregion Property

        #region Constructor

        public ProviderPhotoController(IProviderPhotoSrv ProviderPhotoSrv)
        {
            _ProviderPhotoSrv = ProviderPhotoSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// اتصال تصویر به تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproviderphoto")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProviderPhoto([FromBody] AddProviderPhotoRequest model)
        {
            return Ok(await _ProviderPhotoSrv.AddProviderPhotoAsync(model));
        }

        /// <summary>
        /// دریافت تمام تصاویر تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تصاویر محصولات بازگشت داده می شود</returns>
        [HttpGet("getproviderphoto")]
        public async Task<IActionResult> GetProviderPhoto([FromQuery] GetProviderPhotoRequest model)
        {
            return Ok(await _ProviderPhotoSrv.GetProviderPhotoAsync(model));
        }

        /// <summary>
        /// حذف اتصال تصویر به تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("deleteproviderphoto")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteProviderPhoto([FromBody] DeleteProviderPhotoRequest model)
        {
            return Ok(await _ProviderPhotoSrv.DeleteProviderPhotoAsync(model));
        }

        #endregion Methods
    }
}