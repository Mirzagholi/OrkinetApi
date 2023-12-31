﻿using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.API.Controllers.Common
{
    [ApiController, Route("api/common/category")]
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

        #endregion Methods
    }
}