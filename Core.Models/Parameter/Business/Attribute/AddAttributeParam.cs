using Core.Common.Base;

namespace Core.Models.Parameter.Business.Attribute
{
    public class AddAttributeParam : BaseParam
    {
        public string Name { get; set; }
        public int? Order { get; set; }
    }
}
