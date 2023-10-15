using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.Blog;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin, Blogger")]
    [ApiController, Route("api/admin/blog")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        /// ثبت بلاگ
        /// </summary>
        /// <param name="request">پارامتر های مورد نیاز</param>
        /// <returns>نتیجه عملیات برگشت داده می شود</returns>
        [HttpPost("addblog")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddBlog([FromForm] AddBlogRequest request)
        {
            return Ok(await _blogSrv.AddBlogAsync(request));
        }

        /// <summary>
        /// ویرایش دسته
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateBlog")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateBlog([FromBody] UpdateBlogRequest model)
        {
            return Ok(await _blogSrv.UpdateBlogAsync(model));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("deleteBlog")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteBlog([FromBody] DeleteBlogRequest model)
        {
            return Ok(await _blogSrv.DeleteBlogAsync(model));
        }

        /// <summary>
        /// دریافت اطلاعات بلاگ
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست اطلاعات مورد نظر بازگشت داده می شود</returns>
        [HttpGet("getallblog")]
        public async Task<ActionResult> GetAllBlog([FromQuery] GetAllBlogRequest model)
        {
            return Ok(await _blogSrv.GetAllBlogAsync(model));
        }

        #endregion Methods
    }
}