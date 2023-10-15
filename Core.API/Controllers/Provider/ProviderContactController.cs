using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.Models.Request.Business.ProviderContact;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/providercontact")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProviderContactController : BaseController
    {
        #region Property

        private readonly IProviderContactSrv _providerContactSrv;

        #endregion Property

        #region Constructor

        public ProviderContactController(IProviderContactSrv providerContactSrv)
        {
            _providerContactSrv = providerContactSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام مخاطبین تامین کننده
        /// </summary>
        /// <returns>لیست ویژگی های عمومی بازگشت داده می شود</returns>
        [HttpGet("getprovidercontact")]
        public async Task<IActionResult> GetProviderContact()
        {
            return Ok(await _providerContactSrv.GetProviderContactAsync());
        }

        /// <summary>
        /// ثبت مخاطبین تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprovidercontact")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> AddProviderContact([FromBody] AddProviderContactRequest model)
        {
            return Ok(await _providerContactSrv.AddProviderContactAsync(model));
        }

        /// <summary>
        /// حذف مخاطبین تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("deleteprovidercontact")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteProviderContact([FromBody] DeleteProviderContactRequest model)
        {
            return Ok(await _providerContactSrv.DeleteProviderContactAsync(model));
        }

        #endregion Methods
    }
}