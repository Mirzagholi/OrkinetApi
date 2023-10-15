using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class ConfirmProviderUserMobileRequest : BaseRequest
    {
        /// <summary>
        /// شناسه موبایل تامین کننده
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// موبایل تامین کننده
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// کد تایید
        /// </summary>
        public int ConfirmCode { get; set; }
    }
}
