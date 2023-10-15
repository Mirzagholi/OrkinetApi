using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Value;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/common/value")]
    public class ValueController : BaseController
    {
        #region Property

        private readonly IValueSrv _valueSrv;

        #endregion Property

        #region Constructor

        public ValueController(IValueSrv valueSrv)
        {
            _valueSrv = valueSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت مقادیر به همراه ویژگی عمومی مناطق بر اساس دسته انتخابی
        /// </summary>
        /// <returns>لیست مقادیر به همراه ویژگی عمومی بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getcompletevaluedropdown")]
        public async Task<ActionResult> GetCompleteValueDropDown()
        {
            return Ok(await _valueSrv.GetCompleteValueDropDownAsync());
        }

        #endregion Methods
    }
}