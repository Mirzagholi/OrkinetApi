using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Base
{
    public abstract class BasePagingRequest : BaseRequest
    {
        /// <summary>
        /// شماره صفحه جاری
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// تعداد ایتم های هر صفحه
        /// </summary>
        public int? PageRecord { get; set; }

        /// <summary>
        /// نام ستون منتخب جهت مرتب سازی
        /// </summary>
        public string SortColumn { get; set; }

        /// <summary>
        /// نوع مرتب سازی ( Desc , Asc )
        /// </summary>
        public string SortOrder { get; set; }
    }
}
