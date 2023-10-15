using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class SetProviderCoordinateRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int Id { get; set; }

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
