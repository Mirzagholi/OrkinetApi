using Core.Common.Base;

namespace Core.Models.Parameter.Security.UserAddress
{
    public class AddUserAddressParam : BaseParam
    {
        public int UserId { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
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
    }
}
