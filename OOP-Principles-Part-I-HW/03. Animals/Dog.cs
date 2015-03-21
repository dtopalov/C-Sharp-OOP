using System;

namespace _03.Animals
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, Gender gender, int age, string breed) : base(name, gender, age)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override void MakeSound()
        {
            Console.WriteLine("{0} is barking", this.Name);
        }
    }
}
