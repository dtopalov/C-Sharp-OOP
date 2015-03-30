namespace _04.Person
{
    using System;

    public class Person
    {
        private string name;
        private int? age;

        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
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

        public int? Age {
            get { return this.age; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age cannot be < 0");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            if (this.Age == null)
            {
                return string.Format("Name: {0}\nAge: Not specified", this.Name);
            }
            return string.Format("Name: {0}\nAge: {1}", this.Name, this.Age);
        }
    }
}
