namespace _02.BankAccounts
{
    using System;

    public class Company : Customer
    {
        private string unifiedIdCode;

        public Company(string customerNumber, string name, string unifiedIdCode) : base(customerNumber, name)
        {
            this.UnifiedIdCode = unifiedIdCode;
        }

        public string UnifiedIdCode {
            get { return this.unifiedIdCode; }
            private set 
            {
                if (!this.unifiedCodeIsValid(value))
                {
                    throw new ArgumentException("Invalid unified id code");
                }
                this.unifiedIdCode = value;
            }
        }

        private bool unifiedCodeIsValid(string unifiedCode)
        {
            if (string.IsNullOrEmpty(unifiedCode) || (unifiedCode.Length != 9 && unifiedCode.Length != 13))
            {
                return false;
            }

            foreach (char ch in unifiedCode)
            {
                if (!char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
