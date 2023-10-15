using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProviderAbsorption;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/providerabsorption")]
    [AllowAnonymous]
    public class ProviderAbsorptionController : BaseController
    {
        #region Property

        private readonly IProviderAbsorptionSrv _providerAbsorptionSrv;

        #endregion Property

        #region Constructor

        public ProviderAbsorptionController(IProviderAbsorptionSrv providerAbsorptionSrv)
        {
            _providerAbsorptionSrv = providerAbsorptionSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// ثبت درخواست جذب تامین کننده
        /// </summary>
        /// <param name="request">پارامتر های مورد نیاز</param>
        /// <returns>نتیجه عملیات برگشت داده می شود</returns>
        [HttpPost("addproviderabsorption")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddProviderAbsorption(AddProviderAbsorptionRequest request)
        {
            return Ok(await _providerAbsorptionSrv.AddProviderAbsorptionAsync(request));
        }

        #endregion Methods
    }
}