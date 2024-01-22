using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Category;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/category")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        /// افزودن دسته
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addcategory")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddCategory([FromBody]AddCategoryRequest model)
        {
            return Ok(await _categorySrv.AddCategoryAsync(model));
        }

        /// <summary>
        /// ویرایش دسته
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updatecategory")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryRequest model)
        {
            return Ok(await _categorySrv.UpdateCategoryAsync(model));
        }

        /// <summary>
        /// تغییر وضعیت دسته
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه وضعیت ( 1 : فعال | 2 : غیر فعال | 3: حذف شده )</remarks>
        [HttpPost("updatecategorystatus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateCategoryStatus([FromBody] UpdateCategoryStatusRequest model)
        {
            return Ok(await _categorySrv.UpdateCategoryStatusAsync(model));
        }

        /// <summary>
        /// دریافت دسته بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه دسته</param>
        /// <returns>دسته انتخابی بازگشت داده می شود</returns>
        [HttpGet("getcategorybyid")]
        public async Task<ActionResult> GetCategoryById(int id)
        {
            return Ok(await _categorySrv.GetCategoryByIdAsync(id));
        }

        /// <summary>
        /// دریافت تمام دسته ها
        /// </summary>
        /// <returns>لیست دسته ها بازگشت داده می شود</returns>
        [HttpGet("getcategory")]
        public async Task<ActionResult> GetCategory()
        {
            return Ok(await _categorySrv.GetCategoryAsync());
        }


        


        #endregion Methods
    }
}