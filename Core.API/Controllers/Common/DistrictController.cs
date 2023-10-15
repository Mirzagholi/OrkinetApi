using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Base;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/district")]
    public class DistrictController : BaseController
    {
        #region Property

        private readonly IDistrictSrv _districtSrv;

        #endregion Property

        #region Constructor
        public DistrictController(IDistrictSrv districtSrv)
        {
            _districtSrv = districtSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام محله بر اساس شهر انتخابی
        /// </summary>
        /// <param name="cityId">شناسه شهر</param>
        /// <returns>لیست محله ها بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getdistrict")]
        public async Task<ActionResult> GetDistrict(int cityId)
        {
            return Ok(await _districtSrv.GetDistrictAsync(cityId));
        }

        #endregion Methods
    }
}