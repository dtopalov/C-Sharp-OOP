namespace _20.InfiniteSeries
{
    using System;
    using System.Numerics;

    class InfiniteConvergentSeries
    {
        public delegate double CalcConvergentSeries(double precision);  

        static void Main()
        {
            var dlg1 = new CalcConvergentSeries(CalcConvergentSum);
            var dlg2 = new CalcConvergentSeries(CalcConvergentSeriesAlternatingSign);
            var dlg3 = new CalcConvergentSeries(CalcConvergentSumFactorial);

           Console.WriteLine("1 + 1/2 + 1/4 + 1/8 + ... with precision {0} = {1}",
                0.01, CalcInfiniteConvergentSeries(0.01, dlg1));

           Console.WriteLine("1 + 1/2 - 1/4 + 1/8 - ... with precision {0} = {1}",
                0.01, CalcInfiniteConvergentSeries(0.01, dlg2));

           Console.WriteLine("1 + 1/2! + 1/3! + 1/4! - ... with precision {0} = {1}",
               0.01, CalcInfiniteConvergentSeries(0.01, dlg3));
        }

        public static double CalcInfiniteConvergentSeries(double precision, CalcConvergentSeries dlg)
        {
            return dlg(precision);
        }

        public static BigInteger CalcFactorial(int number)
        {
            BigInteger result = 1;

            if (number < 0)
            {
                throw new ArgumentException("Can not calculate factorial of a negative number");
            }
            else
            {
                for (int i = 1; i <= number; i++)
                {
                    result *= i;
                }    
            }

            return result;
        }

        public static BigInteger TwoToPower(int number)
        {
            BigInteger result = 1;

            for (int i = 0; i < number; i++)
            {
                result *= 2;
            }

            return result;
        }

        public static double CalcConvergentSum(double precision)
        {
            double result = 1;
            if (precision <= 0)
            {
                throw new ArgumentException("Precision must be > 0");
            }

            double previousResult = 0;
            int counter = 1;

            while (result - previousResult > precision)
            {
                previousResult = result;
                result += 1/(double) TwoToPower(counter);
                counter++;
            }
           
            return result;
        }

        public static double CalcConvergentSeriesAlternatingSign(double precision)
        {
            double result = 1;
            if (precision <= 0)
            {
                throw new ArgumentException("Precision must be > 0");
            }
           
            double previousResult = 0;
            int counter = 1;

            while (Math.Abs(result - previousResult) > precision)
            {
                previousResult = result;
                if (counter % 2 == 1)
                {
                    result += 1 / (double)TwoToPower(counter);    
                }
                else
                {
                    result -= 1 / (double)TwoToPower(counter);
                }
                    
                counter++;
            }
           
            return result;
        }

        public static double CalcConvergentSumFactorial(double precision)
        {
            double result = 1;
            if (precision <= 0)
            {
                throw new ArgumentException("Precision must be > 0");
            }

            double previousResult = 0;
            int counter = 2;

            while (result - previousResult > precision)
            {
                previousResult = result;
                result += 1 / (double)CalcFactorial(counter);
                counter++;
            }

            return result;
        }
    }
}
