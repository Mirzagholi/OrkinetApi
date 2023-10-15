using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common.Base
{
    public sealed class BaseProductPagingResult<T, Y, N, M, Z>
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> List { get; set; }
        public IEnumerable<Y> List1 { get; set; }
        public IEnumerable<N> List2 { get; set; }
        public IEnumerable<M> List3 { get; set; }
        public IEnumerable<Z> List4 { get; set; }
    }
}
