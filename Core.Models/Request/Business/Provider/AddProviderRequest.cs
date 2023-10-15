using Core.Common.Base;
using Core.Models.Enum.Business.Provider;

namespace Core.Models.Request.Business.Provider
{
    public class AddProviderRequest : BaseRequest
    {
        /// <summary>
        /// نام تامین کننده
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد شناسایی تامین کننده
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// نوع تامین کننده( فروشگاه : 1 | کیوسک : 2 | عمده فروش : 3 ) 
        /// </summary>
        public ProviderType ProviderTypeId { get; set; }

        /// <summary>
        /// شناسه استان
        /// </summary>
        public int ProvinceId { get; set; }

        /// <summary>
        /// شناسه شهر
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// شناسه منطقه
        /// </summary>
        public int? RegionId { get; set; }

        /// <summary>
        /// آدرس
        /// </summary>
        public string Address { get; set; }
    }
}
