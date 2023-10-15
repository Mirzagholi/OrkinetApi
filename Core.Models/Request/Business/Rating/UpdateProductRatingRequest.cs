using Core.Common.Base;

namespace Core.Models.Request.Business.Rating
{
    public class UpdateProductRatingRequest : BaseRequest
    {
        /// <summary>
        /// شناسه محصول
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// رتبه
        /// </summary>
        public int Rating { get; set; }
    }
}
