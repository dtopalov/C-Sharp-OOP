namespace _03.Animals
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name, int age, string breed)
            : base(name, age, breed)
        {
            this.Gender = Gender.Female;
        }
    }
}