using Core.Common.Base;
using Core.Models.Enum.Common;
using Core.Models.Helper;

namespace Core.Models.ViewModel.Business.Category
{
    public class GetCategoryByIdVm : BaseDataResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int Order { get; set; }
        public string Icon { get; set; }
        public StatusType StatusId { get; set; }
        public string StatusText => StatusId.GetStatusTextByCulture();
        public string Description { get; set; }

    }
}
