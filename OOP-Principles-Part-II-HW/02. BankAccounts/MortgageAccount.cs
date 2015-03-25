namespace _02.BankAccounts
{
    using System;

    public class MortgageAccount : BankAccount, IDepositable
    {
        public MortgageAccount(decimal balance, decimal interest, Customer customer) : base(balance, interest, customer)
        {
        }
        
        //Balance in a mortgage account is actually the amount owed by the customer, so when a deposit is made,
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

                // Optional functionality - invoke some method to return the difference to the customer
            }
        }

        public override decimal CalculateInterest(int months)
        {
            if (months < 0)
            {
                throw new ArgumentException("Months cannot be < 0");
            }

            if (Customer is Individual)
            {
                if (months <= 6)
                {
                    return 0;
                }
                return this.Balance*(this.InterestRate/100)*(months - 6);
            }

            if (months <= 12)
            {
                return (this.Balance * (this.InterestRate / 100) * months)/2;
            }
            return this.Balance * (this.InterestRate / 100) * (months - 12) +
                (this.Balance * (this.InterestRate / 100) * 6);
        }
    }
}
