using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.FinancialDocument;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/financialdocument")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class FinancialDocumentController : BaseController
    {
        #region Property

        private readonly IFinancialDocumentSrv _financialDocumentSrv;

        #endregion Property

        #region Constructor
        public FinancialDocumentController(IFinancialDocumentSrv financialDocumentSrv)
        {
            _financialDocumentSrv = financialDocumentSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن سند مالی
        /// </summary>
        /// <param name="request">پارامتر های مورد نیاز</param>
        /// <returns>نتیجه عملیات برگشت داده می شود</returns>
        [HttpPost("addfinancialdocument")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddFinancialDocument([FromBody] AddFinancialDocumentRequest request)
        {
            return Ok(await _financialDocumentSrv.AddFinancialDocumentAsync(request));
        }

        /// <summary>
        /// دریافت اطلاعات سند مالی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست اطلاعات بازگشت داده می شود</returns>
        [HttpGet("getallfinancialdocument")]
        public async Task<ActionResult> GetAllFinancialDocument([FromQuery] GetAllFinancialDocumentRequest model)
        {
            return Ok(await _financialDocumentSrv.GetAllFinancialDocumentAsync(model));
        }

        /// <summary>
        /// دریافت اطلاعات ریز سند مالی
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست اطلاعات بازگشت داده می شود</returns>
        [HttpGet("getallfinancialdocumentinfo")]
        public async Task<ActionResult> GetAllFinancialDocumentInfo([FromQuery] GetAllFinancialDocumentInfoRequest model)
        {
            return Ok(await _financialDocumentSrv.GetAllFinancialDocumentInfoAsync(model));
        }

        #endregion Methods
    }
}