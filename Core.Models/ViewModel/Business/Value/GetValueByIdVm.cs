using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Value
{
    public class GetValueByIdVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
    }
}
