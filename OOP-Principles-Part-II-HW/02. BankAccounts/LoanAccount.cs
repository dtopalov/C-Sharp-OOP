namespace _02.BankAccounts
{
    using System;

    public class LoanAccount : BankAccount, IDepositable
    {
        public LoanAccount(decimal balance, decimal interest, Customer customer) : base(balance, interest, customer)
        {
        }
        
        //Balance in a loan account is actually the amount owed by the customer, so when a deposit is made,
        //the amount of the deposit is subtracted from the initial balance

        public override void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative");
            }

            if (this.Balance > amount)
            {
                this.Balance -= amount;    
            }
            else
            {
                this.Balance = 0;

                // Optional functionality - invoke a method to return the difference to the customer
            }
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Months cannot be < 0");
            }

            if ((this.Customer is Individual && months <= 3) || (this.Customer is Company && months <= 2))
            {
                return 0;
            }

            return this.Balance*(this.InterestRate/100)*(months - (Customer is Individual ? 3 : 2));
        }
    }
}
