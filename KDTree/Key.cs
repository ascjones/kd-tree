namespace KDTree
{
    public class Key<T> 
    {
        private readonly T[] coords;

        public Key(T[] coords)
        {
            this.coords = coords;
        }

        public int Dimensions
        {
            get { return coords.Length; }
        }

        public T[] Coords
        {
            get { return coords; }
        }
    }
}