using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateValue
{
    public class AddPrivateValueParam : BaseParam
    {
        public string Name { get; set; }
        public int PrivateAttributeId { get; set; }
        public int ProviderId { get; set; }
        public int Order { get; set; }
    }
}
