using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.PrivateValue
{
    public class GetPrivateValueVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PrivateAttributeId { get; set; }
        public string PrivateAttributeName { get; set; }
        public int Order { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
    }
}
