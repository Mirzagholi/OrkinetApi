using Core.Common.Base;

namespace Core.Models.Request.Security.UserAddress
{
    public class UpdateUserAddressRequest : BaseRequest
    {
        /// <summary>
        /// شناسه
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه استان
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// شناسه شهر
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// شناسه محله
        /// </summary>
        public int DistrictId { get; set; }

        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// کد پستی
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        ///  پلاک
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// واحد
        /// </summary>
        public string HouseUnit { get; set; }

        /// <summary>
        /// Latitudes
        /// </summary>
        public decimal Latitudes { get; set; }

        /// <summary>
        /// Longitudes
        /// </summary>
        public decimal Longitudes { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// تحویل گیرنده خودم هستم
        /// </summary>
        public bool DeliveredToMe { get; set; }

        /// <summary>
        /// شماره موبایل
        /// </summary>
        public string MobileNumber { get; set; }
    }
}
