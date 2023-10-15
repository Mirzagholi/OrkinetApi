using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Contact;
using Core.ServiceContract.Business;

namespace Core.Api.Controllers.FrontEnd
{
    [ApiController, Route("api/contactus")]
    [AllowAnonymous]
    public class ContactController : BaseController
    {
        #region Property

        private readonly IContactUsSrv _contactSrv;

        #endregion Property

        #region Constructor
        public ContactController(IContactUsSrv contactSrv)
        {
            _contactSrv = contactSrv;
        }

        #endregion Constructor

        #region Methods


        /// <summary>
        /// ثبت فرم ارتباط با سایت
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        /// <remarks>شناسه نوع فرم ( 1 : نظر و پیشنهاد | 2 : ارتباط با ما | 3: شکایت و انتقاد )</remarks>
        [HttpPost("addcontactus")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddContactUs([FromBody] AddContactUsRequest model)
        {
            return Ok(await _contactSrv.AddContactUsAsync(model));
        }

        #endregion Methods
    }
}