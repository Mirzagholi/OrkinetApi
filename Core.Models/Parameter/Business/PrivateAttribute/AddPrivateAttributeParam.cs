using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateAttribute
{
    public class AddPrivateAttributeParam : BaseParam
    {
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int Order { get; set; }
    }
}
