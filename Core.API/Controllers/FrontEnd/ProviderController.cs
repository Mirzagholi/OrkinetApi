using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/provider")]
    [AllowAnonymous]
    public class ProviderController : BaseController
    {
        #region Property

        private readonly IProviderSrv _providerSrv;

        #endregion Property

        #region Constructor

        public ProviderController(IProviderSrv providerSrv)
        {
            _providerSrv = providerSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تامین کنندگان برای صفحه محصولات
        /// </summary>
        /// <returns>لیست تامین کنندگان بازگشت داده می شود</returns>
        [HttpGet("getproviderui")]
        public async Task<ActionResult> GetProviderUi()
        {
            return Ok(await _providerSrv.GetProviderUiAsync());
        }

        /// <summary>
        /// دریافت تامین کنندگان برای ساید بار
        /// </summary>
        /// <returns>لیست تامین کنندگان بازگشت داده می شود</returns>
        [HttpGet("getproviderlandingsidebar")]
        public async Task<ActionResult> GetProviderLandingSideBar()
        {
            return Ok(await _providerSrv.GetProviderLandingSideBarAsync());
        }

        /// <summary>
        /// دریافت اطلاعات تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>اطلاعات تامین کننده بازگشت داده می شود</returns>
        [HttpGet("getproviderdetailui")]
        public async Task<ActionResult> GetProviderDetailUi([FromQuery] GetProviderDetailUiRequest model)
        {
            return Ok(await _providerSrv.GetProviderDetailUiAsync(model));
        }

        /// <summary>
        /// دریافت نزدیک ترین تامین کنندگان برای صفحه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تامین کنندگان بازگشت داده می شود</returns>
        [HttpGet("getclosestproviderui")]
        public async Task<ActionResult> GetClosestProviderUi([FromQuery] GetClosestProviderUiRequest model)
        {
            return Ok(await _providerSrv.GetClosestProviderUiAsync(model));
        }

        #endregion Methods
    }
}