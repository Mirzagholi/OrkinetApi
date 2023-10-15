using Core.Common.Base;

namespace Core.Models.Request.Business.ProviderContact
{
    public class DeleteProviderContactRequest : BaseRequest
    {
        /// <summary>
        /// شناسه مخاطب
        /// </summary>
        public int Id { get; set; }
    }
}
