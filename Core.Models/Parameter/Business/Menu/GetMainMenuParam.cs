using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Parameter.Business.Menu
{
    public class GetMainMenuParam : BaseParam
    {
        public int MenuTypeId { get; set; }
        public bool IsActiveOnly { get; set; }
    }
}
