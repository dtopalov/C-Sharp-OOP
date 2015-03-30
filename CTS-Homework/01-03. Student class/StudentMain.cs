//Problem 1. Student class

//Define a class Student, which contains data about a student – first, middle and last name, SSN, permanent address, 
//mobile phone e-mail, course, specialty, university, faculty. Use an enumeration for the specialties, universities 
//and faculties.
//Override the standard methods, inherited by System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

namespace _01_03.Student_class
{
    using System;

    class StudentMain
    {
        static void Main()
        {
            Student test = new Student("Ivan", "Ivanov", "Ivanov", "123-45-6789", "Some address", "0888 100 200",
                "ivanov@abv.bg", 3, Universities.SU, Faculty.EconomicsAndBA, Specialty.Economics);

            // Student test2 is the same as test in everything, but SSN
            Student test2 = new Student("Ivan", "Ivanov", "Ivanov", "222-45-6689", "Some address", "0888 100 200",
                "ivanov@abv.bg", 3, Universities.SU, Faculty.EconomicsAndBA, Specialty.Economics);

            // Student test3 - some different properties, but the same SSN as test
            Student test3 = new Student("Gosho", "Petrov", "Dimitrov", "123-45-6789", "Some other address", "0888 120 200",
                "gogo@abv.bg", 3, Universities.UNSS, Faculty.EconomicsAndBA, Specialty.Economics);

            bool compare1and2 = test.Equals(test2);
            bool compare1and3 = test.Equals(test3);
            bool compareWithOperators1and2 = test == test2;
            bool compareWithOperators1and3 = test == test3;
            int newHashCode = test.GetHashCode();

            Console.WriteLine(test); // test toString
            Console.WriteLine("Compare student 1 and student 2 using Equals: {0}\n" +
                              "Compare student 1 and student 3 using Equals: {1}\n" +
                              "Compare student 1 and student 2 using ==: {2}\n" +
                              "Compare student 1 and student 3 using ==: {3}\n",
                              compare1and2, compare1and3, compareWithOperators1and2, compareWithOperators1and3);
            Console.WriteLine("New HashCode of student 1: {0}", newHashCode);

            Student cloned = test.Clone() as Student;

            Console.WriteLine("test.CompareTo(test2): {0}", test.CompareTo(test2)); // (-1): names are the same, but test's SSN < test2's SSN
            Console.WriteLine("test.CompareTo(test3): {0}", test.CompareTo(test3)); // (1): Ivan(test) is after Gosho(test3) lexicographically

            Console.WriteLine("Cloned == test? {0}", cloned == test);
            test = test2; // change test, now it's different from cloned
            Console.WriteLine("Cloned == test after changing test? {0}", test == cloned);
        }
    }
}
