using Core.Common.Base;

namespace Core.Models.Parameter.Business.Category
{
    public class AddCategoryParam : BaseParam
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
        public string Icon { get; set; }
        public int? StatusId { get; set; }
        public string Description { get; set; }
    }
}
