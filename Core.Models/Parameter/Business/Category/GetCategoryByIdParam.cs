using Core.Common.Base;

namespace Core.Models.Parameter.Business.Category
{
    public class GetCategoryByIdParam : BaseParam
    {
        public int Id { get; set; }
    }


    public class GetCategoryInFirstPageParam:BaseParam
    {
        public int? ParentCategoryId { get; set; }


        /// <summary>
        /// تعداد رکورد ها جهت نمایش
        /// </summary>
        public int? PageRecord { get; set; }
    }

}
