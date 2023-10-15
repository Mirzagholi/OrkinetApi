using System.Threading.Tasks;
using Core.Common.Base.Controllers;
using Core.Models.Request.Business.Favorite;
using Core.ServiceContract.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core.Api.Controllers.FrontEnd
{
    [AllowAnonymous]
    [ApiController, Route("api/favorite")]
    public class FavoriteController : BaseController
    {
        #region Property

        private readonly IFavoriteSrv _favoriteSrv;

        #endregion Property

        #region Constructor

        public FavoriteController(IFavoriteSrv favoriteSrv)
        {
            _favoriteSrv = favoriteSrv;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// افزودن محسول به علاقمندی ها
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("addfavorite")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> AddFavorite([FromBody] AddFavoriteRequest model)
        {
            return Ok(await _favoriteSrv.AddFavoriteSAsync(model));
        }

        /// <summary>
        /// حذف محسول از علاقمندی ها
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>نتیجه عملیات بازگشت داده می شود</returns>
        [HttpPost("deletefavorite")]
        [IgnoreAntiforgeryToken]
        public async Task<ActionResult> DeleteFavorite([FromBody] DeleteFavoriteRequest model)
        {
            return Ok(await _favoriteSrv.DeleteFavoriteSAsync(model));
        }

        /// <summary>
        /// دریافت تمام محصولات برای صفحه علاقمندی ها
        /// </summary>
        /// <param name="model">پارامتر های ورودی</param>
        /// <returns>لیست محصولات بازگشت داده می شود</returns>
        [HttpGet("getallfavoriteui")]
        public async Task<ActionResult> GetAllFavoriteUi([FromQuery] GetAllFavoriteUiRequest model)
        {
            return Ok(await _favoriteSrv.GetAllFavoriteUiAsync(model));
        }

        #endregion Methods
    }
}