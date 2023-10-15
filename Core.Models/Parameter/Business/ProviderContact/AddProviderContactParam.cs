using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.ProviderContact
{
    public class AddProviderContactParam : BaseParam
    {
        public string ContactValue { get; set; }
        public ContactType ContactTypeId { get; set; }
        public int ProviderId { get; set; }
    }
}
