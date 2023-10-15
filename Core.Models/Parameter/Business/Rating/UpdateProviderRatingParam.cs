using Core.Common.Base;

namespace Core.Models.Parameter.Business.Rating
{
    public class UpdateProviderRatingParam : BaseParam
    {
        public int ProviderId { get; set; }
        public int Rating { get; set; }
    }
}
