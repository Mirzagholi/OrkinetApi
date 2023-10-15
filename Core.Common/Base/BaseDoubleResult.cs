using System.Collections.Generic;

namespace Core.Common.Base
{
    public sealed class BaseDoubleResult<T, Y>
    {
        public IEnumerable<T> Data1 { get; set; }
        public IEnumerable<Y> Data2 { get; set; }
    }
}
