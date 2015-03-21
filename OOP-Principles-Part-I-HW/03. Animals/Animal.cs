namespace _03.Animals
{
    using System;

    public abstract class Animal : ISound
    {
        private string name;
        private int age;

        public Animal(string name, Gender gender, int age)
        {
            this.Name = name;
            this.Gender = gender;
            this.Age = age;
        }

        public Animal(string name, int age)
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

        public Gender Gender { get; protected set; }

        public int Age {
            get { return this.age; }
            set {
                if (age < 0)
                {
                    throw new ArgumentException("Age cannot be negative");
                }
                this.age = value;
            }
        }

        public abstract void MakeSound();
    }
}
