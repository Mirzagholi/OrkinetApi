using Core.Common.Base;

namespace Core.Models.Parameter.Business.Provider
{
    public class SetProviderCoordinateParam : BaseParam
    {
        public int Id { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
    }
}
