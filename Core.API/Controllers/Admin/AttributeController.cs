using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Attribute;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/attribute")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AttributeController : BaseController
    {
        #region Property

        private readonly IAttributeSrv _attributeSrv;

        #endregion Property

        #region Constructor
        public AttributeController(IAttributeSrv attributeSrv)
        {
            _attributeSrv = attributeSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addattribute")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddAttribute([FromBody] AddAttributeRequest model)
        {
            return Ok(await _attributeSrv.AddAttributeAsync(model));
        }

        /// <summary>
        /// ویرایش ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateattribute")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateAttribute([FromBody] UpdateAttributeRequest model)
        {
            return Ok(await _attributeSrv.UpdateAttributeAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت ویژگی عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updateattributestatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateAttributeStatus([FromBody] UpdateAttributeStatusRequest model)
        {
            return Ok(await _attributeSrv.UpdateAttributeStatusAsync(model));
        }

        /// <summary>
        /// دریافت ویژگی عمومی بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه ویژگی عمومی</param>
        /// <returns>ویژگی عمومی انتخابی بازگشت داده می شود</returns>
        [HttpGet("getattributebyid")]
        public async Task<ActionResult> GetAttributeById(int id)
        {
            return Ok(await _attributeSrv.GetAttributeByIdAsync(id));
        }

        /// <summary>
        /// دریافت تمام ویژگی های عمومی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست ویژگی های عمومی بازگشت داده می شود</returns>
        [HttpGet("getattribute")]
        public async Task<ActionResult> GetAttribute([FromQuery] GetAttributeRequest model)
        {
            return Ok(await _attributeSrv.GetAttributeAsync(model));
        }

        #endregion Methods
    }
}