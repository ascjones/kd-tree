using System;
using System.Collections.Generic;

namespace KDTree
{
    public class DefaultComparer<T> : IComparer<T> where T : IComparable
    {
        public int Compare(T x, T y)
        {
            return x.CompareTo(y);
        }
    }
}
