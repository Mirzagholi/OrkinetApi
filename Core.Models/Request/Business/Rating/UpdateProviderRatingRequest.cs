using Core.Common.Base;

namespace Core.Models.Request.Business.Rating
{
    public class UpdateProviderRatingRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// رتبه
        /// </summary>
        public int Rating { get; set; }
    }
}
