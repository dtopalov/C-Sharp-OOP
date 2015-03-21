namespace _02.StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentsAndWorkersMain
    {
        private static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Ivan", "Ivanov", 5.5),
                new Student("Atanas", "Jelev", 5.0),
                new Student("Gosho", "Petrov", 5.25),
                new Student("Pesho", "Georgiev", 4.5),
                new Student("Ivanka", "Ivanova", 3.5),
                new Student("Maria", "Stoianova", 6.0),
                new Student("Stancho", "Conev", 2),
                new Student("Temenujka", "Rujinska", 4.25),
                new Student("Jetchka", "Slaninkova", 3.75),
                new Student("Gruyo", "Nikolov", 5.5),
            };

            var orderedByGrade = students.OrderBy(x => x.Grade);

            foreach (var student in orderedByGrade)
            {
                Console.WriteLine("Name: " + student.FirstName + " " + student.LastName + ", Grade: " + student.Grade);
            }

            Console.WriteLine();

            List<Worker> workers = new List<Worker>
            {
                new Worker("Ivan", "Georgiev", 200, 6),
                new Worker("Jelyo", "Simeonov", 300, 7),
                new Worker("Gosho", "Kolev", 175, 5.5),
                new Worker("Gosho", "Vasilev", 177.25, 10),
                new Worker("Pesho", "Iskrenov", 700, 9.5),
                new Worker("Filip", "Stoev", 1000, 5),
                new Worker("Stefka", "Asenova", 500, 7.5),
                new Worker("Veska", "Borisova", 600, 8.7),
                new Worker("Genadi", "Petrov", 425.5, 6.125),
                new Worker("Gencho", "Mitev", 550, 8),
            };

            var orderedByEarning = workers.OrderByDescending(x => x.MoneyPerHour());

            foreach (var worker in orderedByEarning)
            {
                Console.WriteLine("Name: {0} {1}; Money per hour: {2:F2}", worker.FirstName, worker.LastName,
                    worker.MoneyPerHour());
            }

            Console.WriteLine("\nMerged and sorted by first and last name: ");
            var merged = students.Concat<Human>(workers).OrderBy(x => x.FirstName).ThenBy(x => x.LastName);

            foreach (var person in merged)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }
    }
}
