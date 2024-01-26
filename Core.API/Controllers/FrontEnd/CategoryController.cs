using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Product;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/category")]
    [AllowAnonymous]
    public class CategoryController : BaseController
    {
        #region Property

        private readonly ICategorySrv _categorySrv;

        #endregion Property

        #region Constructor

        public CategoryController(ICategorySrv categorySrv)
        {
            _categorySrv = categorySrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// دریافت دسته برای باکس کشویی
        /// </summary>
        /// <returns>لیست دسته ها بازگشت داده می شود</returns>
        [AllowAnonymous]
        [HttpGet("getcategorydropdown")]
        public async Task<ActionResult> GetCategoryDropDown()
        {
            return Ok(await _categorySrv.GetCategoryDropDownAsync());
        }


        [AllowAnonymous]
        [HttpGet("getcategoryInFirstPage")]
        public async Task<ActionResult> GetCategoryInFirstPage([FromQuery] GetFirstPageCategoryUiRequest model)
        {
            return Ok(await _categorySrv.GetCategoryInFirstPageAsync(model));
        }



        #endregion Methods
    }
}