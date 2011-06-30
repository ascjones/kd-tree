using System.Collections.Generic;

namespace KDTree
{
    public interface ITree<TKey, out TValue> 
    {
        IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high);
    }
}