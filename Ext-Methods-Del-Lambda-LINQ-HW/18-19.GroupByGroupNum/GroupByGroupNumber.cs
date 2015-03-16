namespace _18_19.GroupByGroupNum
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using _09._16.Problems_9_16;

    class GroupByGroupNumber
    {
        static void Main()
        {
            StudentsTasksMain.sampleStudents.Add(
                new Student("Ivan", "Ivanov", "001212","0878121212","vankata@gmail.com", 
                    new List<int>{(int)PossibleMarks.Good, (int)PossibleMarks.Very_good, (int)PossibleMarks.Average}, 3));

            // Problem 18 - Create a program that extracts all students grouped by GroupNumber and then prints 
            // them to the console. Use LINQ.

            var groupedStudents =
                from student in StudentsTasksMain.sampleStudents
                group student by student.GroupNumber
                into groups
                select new
                {
                    Group = groups.Key,
                    Students = groups.ToList()
                };


            foreach (var grouped in groupedStudents)
            {
                Console.WriteLine("\nGroup: {0} Students:\n---------------------\n{1}", grouped.Group,
                    string.Join("\r\n\r\n", grouped.Students));
            }

            // Problem 19 - do the same using extension methods.
            // Uncomment the last foreach if you want to print the result
            // (it is the same as above)

            var groupedStudents2 = StudentsTasksMain.sampleStudents.GroupBy(x => x.GroupNumber,
                (groupNumber, students) => new {Group = groupNumber, Students = students});

            //foreach (var grouped in groupedStudents2)
            //{
            //    Console.WriteLine("\nGroup: {0} Students:\n---------------------\n{1}", grouped.Group,
            //        string.Join("\r\n\r\n", grouped.Students));
            //}
        }
    }
}
