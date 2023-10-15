using Core.Common.Base;

namespace Core.Models.Parameter.Business.Rating
{
    public class UpdateProductRatingParam : BaseParam
    {
        public int ProductId { get; set; }
        public int Rating { get; set; }
    }
}
