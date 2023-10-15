using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.Category;
using Core.ServiceContract.Common;
using Core.Models.Request.Common.Sms;

namespace Core.Api.Controllers.FrontEnd
{
    [AllowAnonymous]
    [ApiController, Route("api/menu")]
    public class MenuController : BaseController
    {
        #region Property

        private readonly IMenuSrv _menuSrv;
        private readonly ISmsSrv _smsSrv;

        #endregion Property

        #region Constructor
        public MenuController(
            IMenuSrv menuSrv,
            ISmsSrv smsSrv)
        {
            _menuSrv = menuSrv;
            _smsSrv = smsSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام دسته های پدر برای کتگوری باکس
        /// </summary>
        /// <returns>لیست دسته های پدر بازگشت داده می شود</returns>
        [HttpGet("getrootmenubox")]
        public async Task<ActionResult> GetRootMenuBox()
        {
            return Ok(await _menuSrv.GetRootMenuBoxAsync());
        }

        /// <summary>
        /// دریافت تمام زیر دسته ها برای کتگوری باکس
        /// </summary>
        /// <returns>ویژگی عمومی انتخابی بازگشت داده می شود</returns>
        [HttpGet("getsubmenubox")]
        public async Task<ActionResult> GetSubMenuBox(int id)
        {
            return Ok(await _menuSrv.GetSubMenuBoxAsync(id));
        }

        /// <summary>
        /// دریافت تمام منوها
        /// </summary>
        /// <returns>لیست منوها بازگشت داده می شود</returns>
        [HttpGet("getlandingmenu")]
        public async Task<ActionResult> GetLandingMenu()
        {
            return Ok(await _menuSrv.GetLandingMenuAsync());
        }

        #endregion Methods
    }
}