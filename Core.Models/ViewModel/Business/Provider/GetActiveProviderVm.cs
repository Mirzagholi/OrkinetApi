using System;
using Core.Common.Base;
using Core.Models.Enum.Business.Provider;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Provider
{
    public class GetActiveProviderVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public ProviderType ProviderTypeId { get; set; }
        public string ProviderTypeText => ProviderTypeId.GetProviderTypeTextByCulture();
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public DateTime CreatedOn { get; set; }
    }
}
