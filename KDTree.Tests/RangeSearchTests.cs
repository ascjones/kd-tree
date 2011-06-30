using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace KDTree.Tests
{
    [TestFixture]
    public class RangeSearchTests
    {
        private readonly IComparer<double> comparer = new DefaultComparer<double>();

        [Test]
        public void CanFindSingleItem()
        {
            var data = new[]
            {
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {2d, 3d}), 1), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {5d, 4d}), 2), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {9d, 6d}), 3), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {4d, 7d}), 4), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {8d, 1d}), 5),
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {7d, 2d}), 6),
            };

            var tree = TreeBuilder.Build(comparer, data);
            var results = tree.Search(new Key<double>(new[] {8d, 1d}), new Key<double>(new[] {8d, 1d}));

            Assert.AreEqual(1, results.Count());
            Assert.That(results.Contains(5));
        }
   
        [Test]
        public void CananFindMultipleItems()
        {
            var data = new[]
            {
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {2d, 3d}), 1), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {5d, 4d}), 2), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {9d, 6d}), 3), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {4d, 7d}), 4), 
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {8d, 1d}), 5),
                new KeyValuePair<Key<double>, int>(new Key<double>(new[] {7d, 2d}), 6),
            };
            var tree = TreeBuilder.Build(comparer, data);
            var results = tree.Search(new Key<double>(new[] {2d, 3d}), new Key<double>(new[] {5d, 4d}));

            Assert.AreEqual(2, results.Count());
            Assert.That(results.Contains(1));
            Assert.That(results.Contains(2));
        }
    }
}
