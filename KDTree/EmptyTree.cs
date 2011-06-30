using System.Collections.Generic;
using System.Linq;

namespace KDTree
{
    class EmptyTree<TKey, TValue> : ITree<TKey, TValue>
    {
        public IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high)
        {
            return Enumerable.Empty<TValue>();
        }
    }
}