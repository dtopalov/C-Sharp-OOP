namespace _02.IEnumerableExt
{
    using System.Collections.Generic;
    using System.Linq;

    public static class IEnumerableExtensions
    {
        public static T SumOfCollection<T>(this IEnumerable<T> collection) where T : struct
        {
            T result = (dynamic) 0;

            foreach (T item in collection)
            {
                result += (dynamic) item;
            }

            return result;
        }

        public static T ProductOfCollection<T>(this IEnumerable<T> collection) where T : struct
        {
            T result = (dynamic)1;

            foreach (T item in collection)
            {
                result *= (dynamic)item;
            }

            return result;
        }

        public static T MinValueInCollection<T>(this IEnumerable<T> collection) where T : struct
        {
            return collection.Min();
        }

        public static T MaxValueInCollection<T>(this IEnumerable<T> collection) where T : struct
        {
            return collection.Max();
        }

        public static double CollectionAverage<T>(this IEnumerable<T> collection) where T : struct
        {
            return (dynamic)collection.SumOfCollection()/collection.Count();
        }
    }
}
