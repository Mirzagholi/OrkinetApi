using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Provider;
using Core.ServiceContract.Base;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/city")]
    public class CityController : BaseController
    {
        #region Property

        private readonly ICitySrv _citySrv;

        #endregion Property

        #region Constructor
        public CityController(ICitySrv citySrv)
        {
            _citySrv = citySrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام شهر بر اساس استان انتخابی
        /// </summary>
        /// <param name="provinceId">شناسه استان</param>
        /// <returns>لیست شهرها بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getcity")]
        public async Task<ActionResult> GetCity(int provinceId)
        {
            return Ok(await _citySrv.GetCityAsync(provinceId));
        }

        #endregion Methods
    }
}