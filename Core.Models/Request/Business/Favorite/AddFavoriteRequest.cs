using Core.Common.Base;

namespace Core.Models.Request.Business.Favorite
{
    public class AddFavoriteRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }
    }
}
