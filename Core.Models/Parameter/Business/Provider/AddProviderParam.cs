using Core.Common.Base;
using Core.Models.Enum.Business.Provider;

namespace Core.Models.Parameter.Business.Provider
{
    public class AddProviderParam : BaseParam
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public ProviderType ProviderTypeId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int? RegionId { get; set; }
        public string Address { get; set; }
    }
}
