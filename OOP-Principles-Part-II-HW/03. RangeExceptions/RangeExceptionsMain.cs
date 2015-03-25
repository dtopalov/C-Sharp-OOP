using System;
using System.Globalization;

namespace _03.RangeExceptions
{
    class RangeExceptionsMain
    {
        static void Main()
        {
            int[] sampleNumbers = {50, 200};

            foreach (int number in sampleNumbers)
            {
                try
                {
                    if (number < 0 || number > 100)
                    {
                        throw new InvalidRangeException<int>(0, 100);
                    }
                    Console.WriteLine("{0} is in the allowed range", number);
                }
                catch (InvalidRangeException<int> ex)
                {
                    Console.WriteLine("{0} - {1}", number, ex.Message);
                }
            }

            Console.WriteLine();

            DateTime[] sampleDates = { new DateTime(1990, 5, 22), DateTime.Now };
            DateTime startDate = new DateTime(1980, 1, 1);
            DateTime endDate = new DateTime(2013, 12, 31, 23, 59, 59);

            foreach (DateTime date in sampleDates)
            {
                try
                {
                    if (date < startDate || date > endDate)
                    {
                        throw new InvalidRangeException<DateTime>(startDate, endDate);
                    }
                    Console.WriteLine("{0:D} is in the allowed range", date);
                }
                catch (InvalidRangeException<DateTime> ex)
                {
                    Console.WriteLine("{0:D} - {1}", date, ex.Message);
                }
            }
        }
    }
}
