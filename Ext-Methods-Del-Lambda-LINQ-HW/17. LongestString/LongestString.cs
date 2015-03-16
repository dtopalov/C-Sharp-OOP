namespace _17.LongestString
{
    using System;
    using System.Linq;

    class LongestString
    {
        static void Main()
        {
            string[] someStrings = new[]
            {
                "qwerty",
                "asfd",
                "longeststring",
                "short",
                "bla"
            };

            Console.WriteLine(GetLongestString(someStrings));
        }

        public static string GetLongestString(string[] input)
        {
            var longest =
                from strings in input
                orderby strings.Length descending
                select strings;

            return longest.ToArray()[0];
        }
    }
}
