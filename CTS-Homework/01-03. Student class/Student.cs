namespace _01_03.Student_class
{
    using System;
    using System.Reflection;
    using System.Text;

    public class Student : ICloneable, IComparable
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string phone;
        private string email;
        private int course;
        private Universities university;
        private Faculty faculty;
        private Specialty specialty;

        public Student(string fName, string mName, string lName, string ssn, 
                string address, string phone, string email, int course, 
                Universities university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = fName;
            this.MiddleName = mName;
            this.LastName = lName;
            this.SSN = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Course = course;
            this.university = university;
            this.faculty = faculty;
            this.specialty = specialty;
        }

        public string FirstName {
            get { return this.firstName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name cannot be null or empty");
                }
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Middle name cannot be null or empty");
                }
                this.middleName = value;
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

        public string SSN {
            get { return this.ssn; }
            private set
            {
                if (!IsValidSSN(value))
                {
                    throw new ArgumentException("SSN is not in the correct format");
                }
                this.ssn = value;
            }
        }

        public string Address {
            get { return this.address; }
            private set { this.address = value; }
        } // implement some validation for address, phone and email if needed

        public string Phone { get { return this.phone; }
            private set { this.phone = value; } }

        public string Email { get { return this.email; }
            private set { this.email = value; } }

        public int Course {
            get { return this.course; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException("Course number must be in the range [1, 5]");
                }
                this.course = value;
            }
        }

        public Universities University { get { return this.university; } }

        public Faculty Faculty { get { return this.faculty; } }

        public Specialty Specialty { get { return this.specialty; } }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var field in this.GetType().GetRuntimeFields())
            {
                result.AppendLine(field.Name + ": " + field.GetValue(this));
            }

            return result.ToString();
        }

        public override bool Equals(object obj)
        {
            var otherStudent = obj as Student;
            if (this.SSN == otherStudent.SSN)
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return student1.Equals(student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !student1.Equals(student2);
        }

        public override int GetHashCode()
        {
            return this.SSN.GetHashCode() ^ this.Email.GetHashCode() ^ this.LastName.GetHashCode();
        }

        private bool IsValidSSN(string ssn) // correct format XXX-XX-XXXX where X is digit
        {
            if (string.IsNullOrEmpty(ssn) || ssn.Length != 11)
            {
                return false;
            }

            for (int i = 0; i < ssn.Length; i++)
            {
                if (i == 3 || i == 6)
                {
                    if (ssn[i] != '-')
                    {
                        return false;
                    }
                }
                else
                {
                    if (!Char.IsDigit(ssn[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int GetSSNasNumber()
        {
            var numbersFromSSN = new StringBuilder();
            foreach (var symbol in this.SSN)
            {
                if (Char.IsDigit(symbol))
                {
                    numbersFromSSN.Append(symbol);
                }
            }

            return int.Parse(numbersFromSSN.ToString());
        }

        public object Clone()
        {
            return new Student(
                this.FirstName.Clone() as string,
                this.MiddleName.Clone() as string,
                this.LastName.Clone() as string,
                this.SSN.Clone() as string,
                this.Address.Clone() as string,
                this.Phone.Clone() as string,
                this.Email.Clone() as string,
                this.Course,
                this.University,
                this.Faculty,
                this.Specialty);
        }

        public int CompareTo(object obj)
        {
            var otherStudent = obj as Student;
            string fullName = this.FirstName + this.MiddleName + this.LastName;
            string otherFullName = otherStudent.FirstName + otherStudent.MiddleName + otherStudent.LastName;

            if (fullName.CompareTo(otherFullName) < 0)
            {
                return -1;
            }
            if (fullName.CompareTo(otherFullName) > 0)
            {
                return 1;
            }
            if (fullName.CompareTo(otherFullName) == 0)
            {
                if (this.GetSSNasNumber() < otherStudent.GetSSNasNumber())
                {
                    return -1;
                }
                if (this.GetSSNasNumber() > otherStudent.GetSSNasNumber())
                {
                    return 1;
                }
                if (this.GetSSNasNumber() == otherStudent.GetSSNasNumber())
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
