using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/provider")]
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
        /// دریافت اطلاعات تامین کننده لاگین شده
        /// </summary>
        /// <returns>اطلاعات تامین کننده انتخابی بازگشت داده می شود</returns>
        [HttpGet("getproviderinfo")]
        public async Task<IActionResult> GetProviderInfo()
        {
            return Ok(await _providerSrv.GetProviderInfoAsync());
        }

        /// <summary>
        /// ویرایش اطلاعات تامین کننده لاگین شده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproviderinfo")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UpdateProviderInfo([FromBody] UpdateProviderInfoRequest model)
        {
            return Ok(await _providerSrv.UpdateProviderInfoAsync(model));
        }

        #endregion Methods
    }
}