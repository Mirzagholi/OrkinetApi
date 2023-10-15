using Core.Common.Base;

namespace Core.Models.Parameter.Business.ProviderContact
{
    public class DeleteProviderContactParam : BaseParam
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
    }
}
