using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.Category
{
    public class UpdateCategoryStatusParam : BaseParam
    {
        public int Id { get; set; }
        public StatusType StatusId { get; set; }
    }
}
