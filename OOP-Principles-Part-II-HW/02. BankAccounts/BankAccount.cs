using System;
using System.Runtime.Remoting;

namespace _02.BankAccounts
{
    public abstract class BankAccount : IDepositable
    {
        protected decimal balance;
        protected decimal interestRate;

        protected BankAccount(decimal balance, decimal interest, Customer customer)
        {
            this.Balance = balance;
            this.InterestRate = interest;
            this.Customer = customer;
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest cannot be < 0");
                }
                this.interestRate = value; 
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance; 
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cannot be < 0");
                }
                this.balance = value;
            }
        }

        public Customer Customer { get; private set; }

        public virtual decimal CalculateInterest(int months)
        {
            return this.Balance * (this.InterestRate / 100) * months;
        }

        public abstract void Deposit(decimal amount);
    }
}
