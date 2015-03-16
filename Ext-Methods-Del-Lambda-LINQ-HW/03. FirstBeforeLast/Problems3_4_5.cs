//Problem 3. First before last
//Write a method that from a given array of students finds all students whose first name 
//is before its last name alphabetically. Use LINQ query operators.

//Problem 4. Age range
//Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.

//Problem 5. Order students
//Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by 
//first name and last name in descending order.
//Rewrite the same with LINQ.

namespace _03.FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Problems3_4_5
    {
        static void Main()
        {
            Student[] arrayOfStudents =
            {
                new Student("Ivan", "Petrov", 12),
                new Student("Atanas", "Georgiev", 22),
                new Student("Georgi", "Atanassov", 50),
                new Student("Stamat", "Dimitrov", 19),
                new Student("Pesho", "Todorov", 27),
                new Student("Pesho", "Ivanov", 27),
                new Student("Pesho", "Peshev", 27),
                new Student("Pesho", "Andreev", 27)
            };

            //All students
            Console.WriteLine("All students:\n");

            for (int i = 0; i < arrayOfStudents.Length; i++)
            {
                Console.WriteLine("Student " + (i + 1) + ": {0}", arrayOfStudents[i]);
            }

            var result = FirstNameBeforeLast(arrayOfStudents);

            //Only students whose first name is before their last alphabetically
            Console.WriteLine("\nStudents whose first name is before their last alphabetically:\n");

            foreach (var student in result)
            {
                Console.WriteLine(student);
            }

            //Only students whose age is between 18 and 24
            Console.WriteLine("\nStudents whose age is between 18 and 24:\n");
            var ageRange = FindPeopleOfCertainAge(arrayOfStudents, 18, 24);

            foreach (var student in ageRange)
            {
                Console.WriteLine(student);
            }

            //Sort using OrderBy() and ThenBy()
            Console.WriteLine("\nStudents sorted by first and then last name using lambda expressions:\n");
            var sortedStudents = arrayOfStudents.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }

            //Sort using OrderBy() and ThenBy()
            Console.WriteLine("\nStudents sorted by first and then last name using LINQ:\n");
            var sortedStudents2 = 
                from student in arrayOfStudents
                orderby student.FirstName descending, student.LastName descending
                select student;

            foreach (var student in sortedStudents2)
            {
                Console.WriteLine(student);
            }
        }

        private static IEnumerable<Student> FirstNameBeforeLast(Student[] students)
        {
            IEnumerable<Student> result =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;

            return result;
        }

        private static IEnumerable<Student> FindPeopleOfCertainAge(Student[] students, int startAge, int endAge)
        {
            IEnumerable<Student> result =
                from student in students
                where student.Age >= startAge && student.Age <= endAge
                select student;

            return result;
        }
    }
}
