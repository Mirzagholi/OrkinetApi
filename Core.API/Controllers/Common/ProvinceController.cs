using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/province")]
    public class ProvinceController : BaseController
    {
        #region Property

        private readonly IProvinceSrv _provinceSrv;

        #endregion Property

        #region Constructor
        public ProvinceController(IProvinceSrv provinceSrv)
        {
            _provinceSrv = provinceSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام استان ها
        /// </summary>
        /// <returns>لیست استان بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getprovince")]
        public async Task<ActionResult> GetProvince()
        {
            return Ok(await _provinceSrv.GetProvinceAsync());
        }

        #endregion Methods
    }
}