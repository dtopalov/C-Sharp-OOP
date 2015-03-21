namespace _03.Animals
{
    using System;

    public class Frog : Animal, ISound
    {
        public Frog(string name, Gender gender, int age) : base(name, gender, age)
        {
            
        }

        public override void MakeSound()
        {
            Console.WriteLine("{0} is croaking", this.Name);
        }
    }
}
