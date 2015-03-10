using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClassesPartI
{
    public class GSMCallHistoryTest //problem 12
    {
        public static GSM testGSM = new GSM("TestGSM", "TestModel");

        public static DateTime testCall2Date = DateTime.Parse("08/03/2015 19:15:30");
        public static DateTime testCall3Date = DateTime.Parse("09/03/2015 14:07:18");
        public static DateTime testCall4Date = DateTime.Parse("10/03/2015 08:15:55");
        public static DateTime testCall5Date = DateTime.Parse("10/03/2015 12:37:03");
        public static DateTime testCall1Date = DateTime.Parse("10/03/2015 09:25:10");

        public static Call[] testCalls = 
        {
            new Call(testCall1Date, 30, "0888111111"),
            new Call(testCall2Date, 40, "0888222222"),
            new Call(testCall3Date, 50, "0888333333"),
            new Call(testCall4Date, 60, "0888444444"),
            new Call(testCall5Date, 100, "0888555555")
        };

        public static void CreateCalltestHistory()
        {
            for (int i = 0; i < testCalls.Length; i++)
            {
                testGSM.AddCalls(testCalls[i]); //using method of the GSM class
            }
        }

        public static void DisplayCalltestHistory()
        {
            Console.WriteLine(testGSM.PrintCallHistory()); //using method of the GSM class
        }

        public static void CalculateAndPrintTestcallsPrice()
        {
            decimal price = testGSM.CalculateTotalCallsPrice(0.37M); //using method of the GSM class
            Console.WriteLine("Total price of test calls: {0:F2}", price);
        }

        public static void RemoveLongestCall()
        {
            Call longestCall = testGSM.CallHistory.OrderBy(x => x.Duration).ToArray()[testGSM.CallHistory.Count - 1]; //getting the longest call from the list of calls
            testGSM.DeleteCalls(longestCall); //using method of the GSM class
        }


    }
}
