using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/providergallery")]
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
        /// دریافت گالری تصاویر تامین کننده
        /// </summary>
        /// <returns>لیست ویژگی های عمومی بازگشت داده می شود</returns>
        [HttpGet("getprovidergallery")]
        public async Task<IActionResult> GetProviderGallery()
        {
            return Ok(await _providerGallerySrv.GetProviderGalleryProAsync());
        }

        #endregion Methods
    }
}