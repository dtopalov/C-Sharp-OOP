namespace _01.School
{
    using System;

    public class Human
    {
        private string name;

        public Human(string name)
        {
            this.Name = name;
        }

        public string Name {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty or null");
                }
                this.name = value;
            }
        }
    }
}
