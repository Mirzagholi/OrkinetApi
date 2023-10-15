using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.PrivateAttribute
{
    public class UpdatePrivateAttributeStatusParam : BaseParam
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
        public int ProviderId { get; set; }
    }
}
