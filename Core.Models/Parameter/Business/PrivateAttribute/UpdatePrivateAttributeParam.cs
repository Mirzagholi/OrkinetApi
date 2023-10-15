using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateAttribute
{
    public class UpdatePrivateAttributeParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int Order { get; set; }
    }
}
