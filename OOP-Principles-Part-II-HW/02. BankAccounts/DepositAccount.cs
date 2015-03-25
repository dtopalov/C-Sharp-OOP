namespace _02.BankAccounts
{
    using System;

    public class DepositAccount : BankAccount, IDepositable, IWithdrawable
    {
        public DepositAccount(decimal balance, decimal interest, Customer customer) 
            : base(balance, interest, customer)
        {
        }

        public override void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative");
            }
            this.Balance += amount;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new ArgumentException("Withdrawal amount cannot excede available balance");
            }
            this.Balance -= amount;
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Months cannot be < 0");
            }

            if (this.Balance < 1000)
            {
                return 0;
            }
            return this.Balance * (this.InterestRate / 100) * months;
        }
    }
}
