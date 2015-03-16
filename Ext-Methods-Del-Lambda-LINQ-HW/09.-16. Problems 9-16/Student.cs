namespace _09._16.Problems_9_16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string fN;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;
        private EmailValidator emailValidator = new EmailValidator();

        public Student(string first, string last, string fNumber, string tel, string email, List<int> allMarks, int group)
        {
            this.FirstName = first;
            this.LastName = last;
            this.FN = fNumber;
            this.Tel = tel;
            this.Email = email;
            this.Marks = allMarks;
            this.GroupNumber = group;
        }

        public string FirstName {
            get { return this.firstName; }
            private set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Last name cannot be null or empty");
                }
                this.lastName = value;
            }
        }
        public string Tel
        {
            get { return this.tel; }
            private set
            {
                if (string.IsNullOrEmpty(value) || (value[0] != '+' && value[0] != '0'))
                {
                    throw new ArgumentException("Tel. cannot be null or empty and must start with + or 0");
                }
                this.tel = value;
            }
        }
        public string Email {
            get { return this.email; }
            private set
            {
                if (!this.emailValidator.IsValidEmail(value))
                {
                    throw new ArgumentException("Invald email");
                }
                this.email = value;
            }
        }
        public List<int> Marks {
            get { return this.marks; }
            private set { this.marks = value; }
        }
        public int GroupNumber {
            get { return this.groupNumber; }
            private set {
                if (value <= 0)
                {
                    throw new ArgumentException("Group number must be > 0");
                }
                this.groupNumber = value;
            }
        }
        public string FN {
            get { return this.fN; }
            private set
            {
                bool isNumber = true;

                foreach (char ch in value)
                {
                    if (!Char.IsDigit(ch))
                    {
                        isNumber = false;
                    }
                }
                
                if (!isNumber)
                {
                    throw new ArgumentException("Faculty number must contain digits only");
                }

                this.fN = value;
            }
        }

        public override string ToString()
        {
            return string.Format("First name: {0}\nLast name: {1}\nFaculty number: {2}\n" +
                                 "Group number: {3}\nMarks: {4}\nPhone: {5}\nEmail: {6}",
                this.firstName, this.lastName, this.fN, this.groupNumber,
                string.Join(", ", this.marks), this.tel, this.email);
        }
    }
}
