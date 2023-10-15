using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.PrivateAttribute;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Provider
{
    [Authorize(Roles = "Provider")]
    [ApiController, Route("api/provider/privateattribute")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PrivateAttributeController : BaseController
    {
        #region Property

        private readonly IPrivateAttributeSrv _privateAttributeSrv;

        #endregion Property

        #region Constructor

        public PrivateAttributeController(IPrivateAttributeSrv privateAttributeSrv)
        {
            _privateAttributeSrv = privateAttributeSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام ویژگی های خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست ویژگی های خصوصی بازگشت داده می شود</returns>
        [HttpGet("getprivateattribute")]
        public async Task<ActionResult> GetPrivateAttribute([FromQuery] GetPrivateAttributeRequest model)
        {
            return Ok(await _privateAttributeSrv.GetPrivateAttributeAsync(model));
        }

        /// <summary>
        /// افزودن ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addprivateattribute")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddPrivateAttribute([FromBody] AddPrivateAttributeRequest model)
        {
            return Ok(await _privateAttributeSrv.AddPrivateAttributeAsync(model));
        }

        /// <summary>
        /// ویرایش ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>

        [HttpPost("updateprivateattribute")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdatePrivateAttribute([FromBody] UpdatePrivateAttributeRequest model)
        {
            return Ok(await _privateAttributeSrv.UpdatePrivateAttributeAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت ویژگی خصوصی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateprivateattributestatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdatePrivateAttributeStatus([FromBody] UpdatePrivateAttributeStatusRequest model)
        {
            return Ok(await _privateAttributeSrv.UpdatePrivateAttributeStatusAsync(model));
        }

        /// <summary>
        /// دریافت تمام ویژگی های خصوصی برای باکس کشویی
        /// </summary>
        /// <returns>لیست ویژگی های خصوصی بازگشت داده می شود</returns>
        [HttpGet("getprivateattributedropdown")]
        public async Task<ActionResult> GetPrivateAttributeDropDown()
        {
            return Ok(await _privateAttributeSrv.GetPrivateAttributeDropDownAsync());
        }

        #endregion Methods
    }
}