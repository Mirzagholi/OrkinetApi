using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/common/storeconfig")]
    public class StoreConfigController : BaseController
    {
        #region Property

        private readonly IStoreConfigSrv _storeConfigSrv;

        #endregion Property

        #region Constructor

        public StoreConfigController(IStoreConfigSrv storeConfigSrv)
        {
            _storeConfigSrv = storeConfigSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تنظیمات فروشگاه
        /// </summary>
        /// <returns>دریافت تنظیمات فروشگاه دریافت می شود</returns>
        [HttpGet("getstoreconfig")]
        public async Task<ActionResult> GetStoreConfig()
        {
            return Ok(await _storeConfigSrv.GetStoreConfigAsync());
        }

        #endregion Methods
    }
}