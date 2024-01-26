using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.WebSiteFile;

namespace Core.Api.Controllers.FrontEnd
{

    [ApiController, Route("api/websitefile")]
    [AllowAnonymous]
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
        /// دریافت تمام فایل ها
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست فایل ها بازگشت داده می شود</returns>

        [HttpGet("getallwebsitefile")]
        public async Task<IActionResult> GetAllWebSiteFile([FromQuery] GetAllWebSiteFileRequest model)
        {
            return Ok(await _webSiteFileSrv.GetAllWebSiteFileAsync(model));
        }



        #endregion Methods
    }
}

