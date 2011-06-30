using System.Collections.Generic;
using System.Linq;

namespace KDTree
{
    public sealed class TreeBuilder
    {
        public static ITree<TKey, TValue> Build<TKey, TValue>(IComparer<TKey> comparer, IEnumerable<KeyValuePair<Key<TKey>, TValue>> data, int depth = 0)
        {
            if (data.Any() == false)
                return new EmptyTree<TKey, TValue>();

            int k = data.First().Key.Dimensions; // assumes all points have same number of coords
            int axis = depth % k;
            var sortedData = data.OrderBy(p => p.Key.Coords[axis]);

            int medianIndex = sortedData.Count() / 2;
            var median = sortedData.ElementAt(medianIndex);

            var leftTree = Build(comparer, data.Take(medianIndex), depth + 1);
            var rightTree = Build(comparer, data.Skip(medianIndex + 1), depth + 1);
            return new Tree<TKey, TValue>(depth, comparer, median.Key, median.Value, leftTree, rightTree);
        }
    }
}
