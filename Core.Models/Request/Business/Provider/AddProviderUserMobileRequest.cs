using Core.Common.Base;

namespace Core.Models.Request.Business.Provider
{
    public class AddProviderUserMobileRequest : BaseRequest
    {
        /// <summary>
        /// شناسه تامین کننده
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// موبایل تامین کننده
        /// </summary>
        public string Mobile { get; set; }
    }
}
