using Core.Common.Base;

namespace Core.Models.Parameter.Business.PrivateValue
{
    public class UpdatePrivateValueParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public int PrivateAttributeId { get; set; }
        public int Order { get; set; }
    }
}
