using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core.Common.Base.Controllers;
using Core.ServiceContract.Business;
using Core.Models.Request.Business.Rating;

namespace Core.Api.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    [ApiController, Route("api/admin/rating")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class RatingController : BaseController
    {
        #region Property

        private readonly IRatingSrv _ratingSrv;

        #endregion Property

        #region Constructor
        public RatingController(IRatingSrv ratingSrv)
        {
            _ratingSrv = ratingSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// به روز رسانی رتبه محصولات
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproductrating")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateProductRating([FromBody] UpdateProductRatingRequest model)
        {
            return Ok(await _ratingSrv.UpdateProductRatingAsync(model));
        }

        /// <summary>
        /// به روز رسانی رتبه تامین کننده
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("updateproviderrating")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> UpdateProviderRating([FromBody] UpdateProviderRatingRequest model)
        {
            return Ok(await _ratingSrv.UpdateProviderRatingAsync(model));
        }

        #endregion Methods
    }
}