//Problem 1. StringBuilder.Substring

//Implement an extension method Substring(int index, int length) for the class StringBuilder that returns 
//new StringBuilder and has the same functionality as Substring in the class String.

namespace _01.StrBuilderSubstr
{
    using System;
    using System.Text;


    class StringbuilderSubstringMain
    {
        static void Main()
        {
            StringBuilder testStringBuilder = new StringBuilder("Some text for testing purposes");

            //Testing method Substring with parameters starting index and desired substring length
            //returns StringBuilder from index 3 ('e') with length 5 ("e tex"); can be called in different ways:

            StringBuilder testSubstring1 = testStringBuilder.Substring(3, 5);
            StringBuilder testSubstring2 = StringBuilderSubstring.Substring(testStringBuilder, 3, 5);

            Console.WriteLine("Result from the two tests (the same):\ntestSubstring1: {0}\ntestSubstring2: {1}",
                testSubstring1, testSubstring2);

            //Testing method Substring with parameter starting index, returning the substring from the given index
            //to the end of the initial string: ex: Substring(15) returns "testing purposes"

            StringBuilder testSubstring3 = testStringBuilder.Substring(14);
            StringBuilder testSubstring4 = StringBuilderSubstring.Substring(testStringBuilder, 14);

            Console.WriteLine("Result from the next two tests (the same):\ntestSubstring3: {0}\ntestSubstring4: {1}",
                testSubstring3, testSubstring4);
        }
    }
}
