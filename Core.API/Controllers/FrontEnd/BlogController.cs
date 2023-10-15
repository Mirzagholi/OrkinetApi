using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [AllowAnonymous]
    [ApiController, Route("api/blog")]
    public class BlogController : BaseController
    {
        #region Property

        private readonly IBlogSrv _blogSrv;

        #endregion Property

        #region Constructor

        public BlogController(IBlogSrv blogSrv)
        {
            _blogSrv = blogSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت لیست بلاگ برای صفحه لندینگ
        /// </summary>
        /// <returns>لیست بلاگ بازگشت داده می شود</returns>
        [HttpGet("getallblogui")]
        public async Task<ActionResult> GetAllBlogUi()
        {
            return Ok(await _blogSrv.GetAllBlogUiAsync());
        }

        /// <summary>
        /// دریافت بلاگ انتخابی برای صفحه لندینگ
        /// </summary>
        /// <returns> بلاگ بازگشت داده می شود</returns>
        [HttpGet("getallbloginfoui")]
        public async Task<ActionResult> GetAllBlogInfoUi(int id)
        {
            return Ok(await _blogSrv.GetAllBlogInfoUiAsync(id));
        }


        #endregion Methods
    }
}