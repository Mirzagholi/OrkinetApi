using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.FrontEnd
{
    [AllowAnonymous]
    [ApiController, Route("api/sidebar")]
    public class SideBarController : BaseController
    {
        #region Property

        private readonly ISideBarSrv _sideBarSrv;

        #endregion Property

        #region Constructor
        public SideBarController(ISideBarSrv sideBarSrv)
        {
            _sideBarSrv = sideBarSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام ساید براها
        /// </summary>
        /// <returns>لیست ساید بار بازگشت داده می شود</returns>
        [HttpGet("getlandingsidebar")]
        public async Task<ActionResult> GetLandingSideBar(int menuId)
        {
            return Ok(await _sideBarSrv.GetLandingSideBarAsync(menuId));
        }

        #endregion Methods
    }
}