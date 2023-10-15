using Core.Common.Base;
using Core.Models.Enum.Business.Product;

namespace Core.Models.Request.Business.Favorite
{
    public class DeleteFavoriteRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }
    }
}
