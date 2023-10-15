using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Base
{
    public sealed class BaseProductDetailResult<T>
    {
        public T Product { get; set; }
        public IEnumerable<int> CdnFileIdes { get; set; }
    }
}
