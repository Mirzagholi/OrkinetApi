using Core.Common.Base;

namespace Core.Models.Parameter.Business.Value
{
    public class UpdateValueParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AttributeId { get; set; }
        public int? Order { get; set; }
    }
}
