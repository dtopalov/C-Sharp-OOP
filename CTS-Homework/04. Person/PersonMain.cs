namespace _04.Person
{
    using System;

    class PersonMain
    {
        static void Main()
        {
            Person pesho = new Person("Pesho");
            Person gosho = new Person("Gosho", 25);

            Console.WriteLine("Person with unspecified age:\n{0}", pesho);
            Console.WriteLine();
            Console.WriteLine("Person with specified age:\n{0}", gosho);
        }
    }
}
