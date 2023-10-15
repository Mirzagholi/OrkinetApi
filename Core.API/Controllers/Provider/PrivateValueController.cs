using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.PrivateValue;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/privatevalue")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PrivateValueController : BaseController
    {
        #region Property

        private readonly IPrivateValueSrv _privateValueSrv;

        #endregion Property

        #region Constructor

        public PrivateValueController(IPrivateValueSrv privateValueSrv)
        {
            _privateValueSrv = privateValueSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن مقدار ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprivatevalue")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddPrivateValue([FromBody] AddPrivateValueRequest model)
        {
            return Ok(await _privateValueSrv.AddPrivateValueAsync(model));
        }

        /// <summary>
        /// دریافت تمام مقادیر ویژگی های خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست مقادیر ویژگی های خصوصی بازگشت داده می شود</returns>
        [HttpGet("getprivatevalue")]
        public async Task<ActionResult> GetPrivateValue([FromQuery] GetPrivateValueRequest model)
        {
            return Ok(await _privateValueSrv.GetPrivateValueAsync(model));
        }

        /// <summary>
        /// ویرایش مقدار ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateprivatevalue")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdatePrivateValue([FromBody] UpdatePrivateValueRequest model)
        {
            return Ok(await _privateValueSrv.UpdatePrivateValueAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت مقدار ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateprivatevaluestatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdatePrivateValueStatus([FromBody] UpdatePrivateValueStatusRequest model)
        {
            return Ok(await _privateValueSrv.UpdatePrivateValueStatusAsync(model));
        }

        /// <summary>
        /// دریافت تمام مقادیر ویژگی خصوصی برای باکس کشویی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست مقادیر ویژگی های خصوصی بازگشت داده می شود</returns>
        [HttpGet("getcompleteprivatevaluedropdown")]
        public async Task<ActionResult> GetCompletePrivateValueDropDown
            ([FromQuery] GetCompletePrivateValueRequest model)
        {
            return Ok(await _privateValueSrv.GetCompletePrivateValueDropDownAsync(model));
        }

        #endregion Methods
    }
}