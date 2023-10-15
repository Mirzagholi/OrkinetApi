using Core.Common.Base;

namespace Core.Models.ViewModel.Business.Value
{
    public class GetCompleteValueDropDownVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AttributeName { get; set; }
        public int AttributeId { get; set; }
    }
}
