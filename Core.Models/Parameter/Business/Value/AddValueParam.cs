using Core.Common.Base;

namespace Core.Models.Parameter.Business.Value
{
    public class AddValueParam : BaseParam
    {
        public string Name { get; set; }
        public int AttributeId { get; set; }
        public int? Order { get; set; }
    }
}
