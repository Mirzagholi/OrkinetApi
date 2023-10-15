using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.ProductComment;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/productcomment")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ProductCommentController : BaseController
    {
        #region Property

        private readonly IProductCommentSrv _productCommentSrv;

        #endregion Property

        #region Constructor
        public ProductCommentController(IProductCommentSrv productCommentSrv)
        {
            _productCommentSrv = productCommentSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت تمام نظرات کاربران
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست نظرات کاربران بازگشت داده می شود</returns>
        [HttpGet("getallproductcomment")]
        public async Task<ActionResult> GetAllProductComment([FromQuery] GetAllProductCommentRequest model)
        {
            return Ok(await _productCommentSrv.GetAllProductCommentAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت نظر
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproductcommentconfirm")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateProductCommentConfirm([FromBody] UpdateProductCommentConfirmRequest model)
        {
            return Ok(await _productCommentSrv.UpdateProductCommentConfirmAsync(model));
        }

        /// <summary>
        /// پاسخ نظر ادمین
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("replyadminproductcomment")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> ReplyAdminProductComment([FromBody] ReplyAdminProductCommentRequest model)
        {
            return Ok(await _productCommentSrv.ReplyAdminProductCommentAsync(model));
        }

        /// <summary>
        /// دریافت تمام پاسخ نظرات
        /// </summary>
        /// <param name="productCommentId">شناسه کامنت</param>
        /// <returns>لیست نظرات کاربران بازگشت داده می شود</returns>
        [HttpGet("getallproductcommentreply")]
        public async Task<ActionResult> GetAllProductCommentReply(int productCommentId)
        {
            return Ok(await _productCommentSrv.GetAllProductCommentReplyAsync(productCommentId));
        }

        #endregion Methods
    }
}

