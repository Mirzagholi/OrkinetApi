using Microsoft.AspNetCore.Mvc;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/index")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class IndexController : BaseController
    {
        #region Property

        private readonly IIndexSrv _indexSrv;

        #endregion Property

        #region Constructor

        public IndexController(IIndexSrv indexSrv)
        {
            _indexSrv = indexSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت اطلاعات صفحه اصلی برای سبد خرید
        /// </summary>
        /// <returns>اطلاعات صفحه اصلی بازگشت داده می شود</returns>
        [HttpGet("getproviderindexdata")]
        public async Task<ActionResult> GetProviderIndexData()
        {
            return Ok(await _indexSrv.GetProviderIndexDataAsync());
        }

        #endregion Methods
    }
}