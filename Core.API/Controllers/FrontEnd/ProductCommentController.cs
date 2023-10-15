using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.ProductComment;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/productcomment")]
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
        /// ثبت نظر کاربر
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("adduserproductcomment")]
        [IgnoreAntiforgeryToken]
        [Authorize]
        public async Task<ActionResult> AddUserProductComment([FromBody] AddUserProductCommentRequest model)
        {
            return Ok(await _productCommentSrv.AddUserProductCommentAsync(model));
        }

        /// <summary>
        /// دریافت تمام نظرات محصول
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست نظرات بازگشت داده می شود</returns>       
        [AllowAnonymous]
        [HttpGet("getallproductcommentui")]
        public async Task<ActionResult> GetAllProductCommentUi([FromQuery] GetAllProductCommentUiRequest model)
        {
            return Ok(await _productCommentSrv.GetAllProductCommentUiAsync(model));
        }

        #endregion Methods
    }
}