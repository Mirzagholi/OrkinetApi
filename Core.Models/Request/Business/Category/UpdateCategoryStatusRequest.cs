using Core.Common.Base;
using Core.Models.Enum.Common;

namespace Core.Models.Request.Business.Category
{
    public class UpdateCategoryStatusRequest : BaseRequest
    {
        /// <summary>
        /// شناسه دسته
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// شناسه وضعیت ویژگی عمومی
        /// </summary>
        public StatusType StatusId { get; set; }
    }
}
