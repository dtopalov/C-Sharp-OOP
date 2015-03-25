namespace _02.BankAccounts
{
    using System;

    public class Individual : Customer
    {
        private DateTime dateOfBirth;
        private string personalIdNumber;

        public Individual(string customerNumber, string name, string personalIdNumber, DateTime dateOfBirth, Gender gender)
            : base(customerNumber, name)
        {
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PersonalIdNumber = personalIdNumber;
        }

        public DateTime DateOfBirth {
            get { return this.dateOfBirth; }
            private set
            {
                if (!this.IsOfAge(value))
                {
                    throw new ArgumentException("Customer must be at least 18-years-old");
                }
                this.dateOfBirth = value;
            }
        }

        public string PersonalIdNumber
        {
            get { return this.personalIdNumber; }
            private set
            {
                if (!this.personalNumberIsValid(value))
                {
                    throw new ArgumentException("Invalid personal id number");
                }
                this.personalIdNumber = value;
            }
        }

        public Gender Gender { get; private set; }

        private bool IsOfAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;
            if (dateOfBirth > today.AddYears(-age)) age--;

            if (age >= 18)
            {
                return true;
            }
            return false;
        }

        private bool personalNumberIsValid(string personalNumber)
        {
            if (string.IsNullOrEmpty(personalNumber) || personalNumber.Length != 10)
            {
                return false;
            }

            foreach (char ch in personalNumber)
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
