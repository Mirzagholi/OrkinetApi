using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.PrivateValue
{
    public class UpdatePrivateValueStatusParam : BaseParam
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
        public int ProviderId { get; set; }
        public int PrivateAttributeId { get; set; }
    }
}
