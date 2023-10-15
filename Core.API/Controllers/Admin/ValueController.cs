using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Value;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/value")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        /// افزودن مقدار ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addvalue")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddValue([FromBody] AddValueRequest model)
        {
            return Ok(await _valueSrv.AddValueAsync(model));
        }

        /// <summary>
        /// ویرایش مقدار ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updatevalue")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateValue([FromBody] UpdateValueRequest model)
        {
            return Ok(await _valueSrv.UpdateValueAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت مقدار ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updatevaluestatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateValueStatus([FromBody] UpdateValueStatusRequest model)
        {
            return Ok(await _valueSrv.UpdateValueStatusAsync(model));
        }

        /// <summary>
        /// دریافت مقدار ویژگی عمومی بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه مقدار ویژگی عمومی</param>
        /// <returns>مقدار ویژگی عمومی انتخابی بازگشت داده می شود</returns>
        [HttpGet("getvaluebyid")]
        public async Task<ActionResult> GetValueById(int id)
        {
            return Ok(await _valueSrv.GetValueByIdAsync(id));
        }

        /// <summary>
        /// دریافت تمام مقدار ویژگی های عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست مقدار ویژگی های عمومی بازگشت داده می شود</returns>
        [HttpGet("getvalue")]
        public async Task<ActionResult> GetValue([FromQuery] GetValueRequest model)
        {
            return Ok(await _valueSrv.GetValueAsync(model));
        }

        #endregion Methods
    }
}