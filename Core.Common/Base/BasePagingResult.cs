using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Base
{
    public sealed class BasePagingResult<T>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> List { get; set; }
    }
}
