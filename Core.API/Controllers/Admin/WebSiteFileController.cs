using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.WebSiteFile;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin, Blogger")]
    [ApiController, Route("api/admin/websitefile")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class WebSiteFileController : BaseController
    {
        #region Property

        private readonly IWebSiteFileSrv _webSiteFileSrv;

        #endregion Property

        #region Constructor
        public WebSiteFileController(IWebSiteFileSrv webSiteFileSrv)
        {
            _webSiteFileSrv = webSiteFileSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن فایل
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addwebsitefile")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddWebSiteFile([FromForm] AddWebSiteFileRequest model)
        {
            return Ok(await _webSiteFileSrv.AddWebSiteFileAsync(model));
        }

        /// <summary>
        /// دریافت تمام فایل ها
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست فایل ها بازگشت داده می شود</returns>

        [HttpGet("getallwebsitefile")]
        public async Task<IActionResult> GetAllWebSiteFile([FromQuery] GetAllWebSiteFileRequest model)
        {
            return Ok(await _webSiteFileSrv.GetAllWebSiteFileAsync(model));
        }

        /// <summary>
        /// حذف فایل
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("deletewebsitefile")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> DeleteWebSiteFile(DeleteWebSiteFileRequest model)
        {
            return Ok(await _webSiteFileSrv.DeleteWebSiteFileAsync(model));
        }

        #endregion Methods
    }
}
