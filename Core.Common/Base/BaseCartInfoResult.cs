using System.Collections.Generic;

namespace Core.Common.Base
{
    public sealed class BaseCartInfoResult<T, Y>
    {
        public IEnumerable<T> Products { get; set; }
        public Y CartInfo { get; set; }
    }
}
