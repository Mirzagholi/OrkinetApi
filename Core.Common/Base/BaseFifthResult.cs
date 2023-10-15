using System.Collections.Generic;

namespace Core.Common.Base
{
    public sealed class BaseFifthResult<T, Y, N, M, Z>
    {
        public IEnumerable<T> List1 { get; set; }
        public IEnumerable<Y> List2 { get; set; }
        public IEnumerable<N> List3 { get; set; }
        public IEnumerable<M> List4 { get; set; }
        public IEnumerable<Z> List5 { get; set; }
    }
}
