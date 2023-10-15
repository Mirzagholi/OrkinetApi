using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Base
{
    public abstract class BasePagingParam : BaseParam
    {
        public int? PageNumber { get; set; }
        public int? PageRecord { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
    }
}
