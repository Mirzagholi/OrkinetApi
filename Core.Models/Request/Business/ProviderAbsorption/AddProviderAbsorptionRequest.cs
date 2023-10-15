using Core.Common.Base;

namespace Core.Models.Request.Business.ProviderAbsorption
{
    public class AddProviderAbsorptionRequest : BaseRequest
    {
        /// <summary>
        /// نام
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// نام تامین کننده
        /// </summary>
        public string ProviderName { get; set; }

        /// <summary>
        /// شماره تماس
        /// </summary>
        public string PhoneNumber { get; set; }


        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
    }
}
