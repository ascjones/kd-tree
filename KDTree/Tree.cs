using System.Collections.Generic;
using System.Linq;

namespace KDTree
{
    internal sealed class Tree<TKey, TValue> : ITree<TKey, TValue>
    {
        private readonly IComparer<TKey> comparer;
        private readonly int depth;
        private readonly Key<TKey> key;
        private readonly TValue value;
        private readonly ITree<TKey, TValue> left;
        private readonly ITree<TKey, TValue> right;

        internal Tree(int depth, IComparer<TKey> comparer, Key<TKey> key, TValue value, ITree<TKey, TValue> left, ITree<TKey, TValue> right)
        {
            this.depth = depth;
            this.comparer = comparer;
            this.key = key;
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public IEnumerable<TValue> Search(Key<TKey> low, Key<TKey> high)
        {
            int k = key.Dimensions; // assumes all points have same number of coords
            int axis = depth % k;

            if (comparer.Compare(low.Coords[axis], key.Coords[axis]) <= 0)
            {
                foreach (var point in left.Search(low, high))
                    yield return point;
            }

            var keyWithinRange = 
                key.Coords.Select((coord, i) => new { coord, i }).All(x => 
                    comparer.Compare(low.Coords[x.i], x.coord) <= 0 && 
                    comparer.Compare(high.Coords[x.i], x.coord) >= 0);

            if (keyWithinRange) 
                yield return value;

            if (comparer.Compare(high.Coords[axis], key.Coords[axis]) > 0)
            {
                foreach (var point in right.Search(low, high))
                    yield return point;
            }
        }
    }
}
