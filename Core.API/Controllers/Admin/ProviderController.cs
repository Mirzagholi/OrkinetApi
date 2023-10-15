using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/provider")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        /// افزودن تامیین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprovider")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddProvider([FromBody] AddProviderRequest model)
        {
            return Ok(await _providerSrv.AddProviderAsync(model));
        }

        /// <summary>
        /// دریافت تمام تامین کنندگان
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تامین کنندگان بازگشت داده می شود</returns>
        [HttpGet("getprovider")]
        public async Task<ActionResult> GetProvider([FromQuery] GetProviderRequest model)
        {
            return Ok(await _providerSrv.GetProviderAsync(model));
        }

        /// <summary>
        /// دریافت تمام تامین کنندگان فعال
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست تامین کنندگان بازگشت داده می شود</returns>
        [HttpGet("getactiveprovider")]
        public async Task<ActionResult> GetActiveProvider([FromQuery] GetActiveProviderRequest model)
        {
            return Ok(await _providerSrv.GetActiveProviderAsync(model));
        }

        /// <summary>
        /// افزودن مختصات تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("setprovidercoordinate")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> SetProviderCoordinate([FromBody] SetProviderCoordinateRequest model)
        {
            return Ok(await _providerSrv.SetProviderCoordinateAsync(model));
        }

        /// <summary>
        /// افزودن موبایل تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addproviderusermobile")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddProviderUserMobile([FromBody] AddProviderUserMobileRequest model)
        {
            return Ok(await _providerSrv.AddProviderUserMobileAsync(model));
        }

        /// <summary>
        /// تایید موبایل تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("confirmproviderusermobile")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> ConfirmProviderUserMobile([FromBody] ConfirmProviderUserMobileRequest model)
        {
            return Ok(await _providerSrv.ConfirmProviderUserMobileAsync(model));
        }

        /// <summary>
        /// ثبت کاربر تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprovideruser")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddProviderUser([FromBody] AddProviderUserRequest model)
        {
            return Ok(await _providerSrv.AddProviderUserAsync(model));
        }
        #endregion Methods
    }
}

