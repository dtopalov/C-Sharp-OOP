namespace _02.BankAccounts
{
    using System;

    public abstract class Customer
    {
        private string name;

        protected Customer(string customerNumber, string name)
        {
            this.CustomerNumber = customerNumber;
            this.Name = name;
        }

        public string Name {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty");
                }
                this.name = value;
            }
        }

        public string CustomerNumber { get; private set; }
    }
}
