//One project with several classes for all of the problems

using System;

namespace DefiningClassesPartI
{
    class DefiningClassesIHW_Main
    {
        static void Main()
        {
            GSMTest.PrintGSMsInfo(GSMTest.GenerateGSMs(3)); //problem 7
            Console.WriteLine(new string('-', 50));
            
            //problem 12
            GSMCallHistoryTest.CreateCalltestHistory();
            GSMCallHistoryTest.DisplayCalltestHistory();
            Console.WriteLine(new string('-', 50));
            GSMCallHistoryTest.CalculateAndPrintTestcallsPrice();
            GSMCallHistoryTest.RemoveLongestCall();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("{0}\n{1}", "Price after the longest call is removed: ", new string('-', 50));
            GSMCallHistoryTest.CalculateAndPrintTestcallsPrice();
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("{0}\n{1}", "Call history after the longest call is removed: ", new string('-', 50));
            GSMCallHistoryTest.DisplayCalltestHistory();
            Console.WriteLine(new string('-', 50));
            GSMCallHistoryTest.testGSM.ClearCallHistory();
            Console.WriteLine("{0}\n{1}", "Call history list is cleared...", new string('-', 50));
            GSMCallHistoryTest.DisplayCalltestHistory();
        }
    }
}
