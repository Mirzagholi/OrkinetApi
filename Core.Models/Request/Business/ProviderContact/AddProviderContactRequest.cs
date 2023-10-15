using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.ProviderContact
{
    public class AddProviderContactRequest : BaseRequest
    {
        /// <summary>
        /// مقدار
        /// </summary>
        public string ContactValue { get; set; }

        /// <summary>
        /// شناسه نوع مخاطب
        /// </summary>
        public ContactType ContactTypeId { get; set; }
    }
}
