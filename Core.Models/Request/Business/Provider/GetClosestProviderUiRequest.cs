using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class GetClosestProviderUiRequest : BaseRequest
    {
        /// <summary>
        /// Latitudes
        /// </summary>
        public decimal Latitudes { get; set; }

        /// <summary>
        /// Longitudes
        /// </summary>
        public decimal Longitudes { get; set; }
    }
}
