using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Base;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/region")]
    public class RegionController : BaseController
    {
        #region Property

        private readonly IRegionSrv _regionSrv;

        #endregion Property

        #region Constructor
        public RegionController(IRegionSrv regionSrv)
        {
            _regionSrv = regionSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام مناطق بر اساس شهر انتخابی
        /// </summary>
        /// <param name="cityId">شناسه شهر</param>
        /// <returns>لیست مناطق بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getregion")]
        public async Task<ActionResult> GetRegion(int cityId)
        {
            return Ok(await _regionSrv.GetRegionAsync(cityId));
        }

        #endregion Methods
    }
}