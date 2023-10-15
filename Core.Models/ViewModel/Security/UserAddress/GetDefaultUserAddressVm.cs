using Core.Common.Base;
using Core.Models.Enum.Common;
using System;

namespace Core.Models.ViewModel.Security.UserAddress
{
    public class GetDefaultUserAddressVm : BaseDataResult
    {
        public int Id { get; set; }
        public string ProvinceText { get; set; }
        public string CityText { get; set; }
        public string DistrictText { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string HouseNumber { get; set; }
        public string HouseUnit { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
