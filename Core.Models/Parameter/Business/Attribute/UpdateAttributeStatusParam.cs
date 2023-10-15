using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.Attribute
{
    public class UpdateAttributeStatusParam : BaseParam
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
    }
}
