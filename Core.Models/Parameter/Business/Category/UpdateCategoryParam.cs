using Core.Common.Base;

namespace Core.Models.Parameter.Business.Category
{
    public class UpdateCategoryParam : BaseParam
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool ShowInFirstPage { get; set; }
    }
}
