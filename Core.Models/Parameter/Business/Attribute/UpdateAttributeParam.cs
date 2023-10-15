using Core.Common.Base;

namespace Core.Models.Parameter.Business.Attribute
{
    public class UpdateAttributeParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Order { get; set; }
    }
}
