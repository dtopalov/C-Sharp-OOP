namespace _02.BankAccounts
{
    using System;

    class BankMain
    {
        static void Main()
        {
            Customer kircho = new Individual("a001", "Kiro", "8503122535", new DateTime(1990, 10, 25), Gender.Male);

            Customer firmata = new Company("a002", "p2p", "503122535");

            Console.WriteLine(firmata is Individual);
            Console.WriteLine(kircho is Individual);

            BankAccount mortgageAccTest = new MortgageAccount(200.2m, 0.6m, kircho);
            BankAccount mortgageAccTest1 = new MortgageAccount(200.2m, 0.6m, firmata);

            Console.WriteLine(mortgageAccTest.CalculateInterest(15));
            Console.WriteLine(mortgageAccTest1.CalculateInterest(15));

            BankAccount loanAccTest = new LoanAccount(200.2m, 0.6m, kircho);
            BankAccount loanAccTest1 = new LoanAccount(200.2m, 0.6m, firmata);

            Console.WriteLine(loanAccTest.CalculateInterest(11));
            Console.WriteLine(loanAccTest1.CalculateInterest(11));

            BankAccount depositAccTest = new DepositAccount(3200.2m, 0.6m, kircho);
            BankAccount depositAccTest1 = new DepositAccount(1200.2m, 0.6m, firmata);

            Console.WriteLine(depositAccTest.CalculateInterest(11));
            Console.WriteLine(depositAccTest1.CalculateInterest(11));

            depositAccTest.Deposit(200);
            Console.WriteLine(depositAccTest.Balance);

            depositAccTest.Withdraw(200);
            Console.WriteLine(depositAccTest.Balance);
        }
    }
}