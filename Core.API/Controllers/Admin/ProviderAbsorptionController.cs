using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.ProviderAbsorption;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/providerabsorption")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        /// دریافت اطلاعات درخواست جذب تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست اطلاعات جذب بازگشت داده می شود</returns>
        [HttpGet("getallproviderabsorption")]
        public async Task<ActionResult> GetAllProviderAbsorption([FromQuery] GetAllProviderAbsorptionRequest model)
        {
            return Ok(await _providerAbsorptionSrv.GetAllProviderAbsorptionAsync(model));
        }

        #endregion Methods
    }
}