using Core.Common.Base;
using System;

namespace Core.Models.ViewModel.Business.Cart
{
    public class GetProviderInquiryCartInfoVm : BaseDataResult
    {
        public string Address { get; set; }
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public string DistrictName { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
        public string HouseUnit { get; set; }
        public DateTime? DailyDeliveryStartOn { get; set; }
        public DateTime? DailyDeliveryEndOn { get; set; }
        public DateTime? TomorrowDeliveryOn { get; set; }
    }
}
