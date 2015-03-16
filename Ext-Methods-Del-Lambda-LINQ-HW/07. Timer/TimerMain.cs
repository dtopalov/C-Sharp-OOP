namespace _07.Timer
{
    using System;

    class TimerMain
    {
        static void Main()
        {
            Timer timer = new Timer(5);

            timer.SomeMethods += FirstTestMethod;
            timer.SomeMethods += SecondTestMethod;

            timer.ExecuteMethods();
        }

        public static void FirstTestMethod()
        {
            Console.WriteLine("This method was added first and will be executed after every given interval");
        }

        public static void SecondTestMethod()
        {
            Console.WriteLine("This method was added second and will be executed after every given interval");
        }
    }
}
