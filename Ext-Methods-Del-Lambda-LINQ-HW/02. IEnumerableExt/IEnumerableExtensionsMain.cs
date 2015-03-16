//Problem 2. IEnumerable extensions

//Implement a set of extension methods for IEnumerable<T> that implement the following 
//group functions: sum, product, min, max, average.

namespace _02.IEnumerableExt
{
    using System;
    using System.Collections.Generic;

    class IEnumerableExtensionsMain
    {
        static void Main()
        {
            //Testing of the various extensions for different types of collections and elements:

            IEnumerable<int> test = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine(test.SumOfCollection());
            IEnumerable<double> test1 = new[] { 1.5, 2.5, 3.5, 4.5, 5.5 };

            Console.WriteLine(test1.SumOfCollection());
            Console.WriteLine(test1.ProductOfCollection());
            Console.WriteLine(test1.MinValueInCollection());
            Console.WriteLine(test1.MaxValueInCollection());
            Console.WriteLine(test1.CollectionAverage());

            Console.WriteLine(IEnumerableExtensions.CollectionAverage(test));
            Console.WriteLine(IEnumerableExtensions.ProductOfCollection(test1));
        }
    }
}
