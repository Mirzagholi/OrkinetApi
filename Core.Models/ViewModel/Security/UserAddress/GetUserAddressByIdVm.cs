using Core.Common.Base;
using Core.Models.Enum.Common;
using System;

namespace Core.Models.ViewModel.Security.UserAddress
{
    public class GetUserAddressByIdVm : BaseDataResult
    {
        public int ProvinceId { get; set; }
        public string ProvinceText { get; set; }
        public int CityId { get; set; }
        public string CityText { get; set; }
        public int DistrictId { get; set; }
        public string DistrictText { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
        public string HouseUnit { get; set; }
        public decimal Latitudes { get; set; }
        public decimal Longitudes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool DeliveredToMe { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
