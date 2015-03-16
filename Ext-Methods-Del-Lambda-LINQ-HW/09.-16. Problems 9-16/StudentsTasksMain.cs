namespace _09._16.Problems_9_16
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentsTasksMain
    {
        // The solutions to all problems from 09 to 16 are separated in 4 regions
        // Uncomment the necessary lines and blocks to print the variuos results

        #region Creating a list of sample students

        public static Student sampleStudent1 = new Student(
            "Atanas", "Petrov", "000114", "02200300", "atanas@abv.bg",
            new List<int>
                {
                    (int)PossibleMarks.Average, 
                    (int)PossibleMarks.Very_good, 
                    (int)PossibleMarks.Poor, 
                    (int)PossibleMarks.Excellent
                },
                2);
        public static Student sampleStudent2 = new Student(
            "Pesho", "Ivanov", "000206", "0888200300", "pesho@abv.bg",
            new List<int>
                {
                    (int)PossibleMarks.Good, 
                    (int)PossibleMarks.Poor, 
                    (int)PossibleMarks.Poor, 
                    (int)PossibleMarks.Average
                }
            , 1);
        public static Student sampleStudent3 = new Student(
            "Gosho", "Atanasov", "000306", "+35928200300", "gosho@mail.bg",
            new List<int>
                {
                    (int)PossibleMarks.Good, 
                    (int)PossibleMarks.Excellent, 
                    (int)PossibleMarks.Very_good, 
                    (int)PossibleMarks.Average
                }
            , 2);

        public static Student sampleStudent4 = new Student(
            "Stamat", "Kolev", "000310", "+359886200300", "stamat@yahoo.com",
            new List<int>
                {
                    (int)PossibleMarks.Good, 
                    (int)PossibleMarks.Poor, 
                    (int)PossibleMarks.Very_good, 
                    (int)PossibleMarks.Average
                }
            , 1);

        public static List<Student> sampleStudents = new List<Student> { sampleStudent1, sampleStudent2, sampleStudent3, sampleStudent4 };

        #endregion

        static void Main()
        {
            #region Performing tasks from problems 9 and 10
            // Print all students

            //for (int i = 1; i <= sampleStudents.Count; i++)
            //{
            //    Console.WriteLine("Student " + i + ":\n");
            //    Console.WriteLine(sampleStudents[i - 1]);
            //    Console.WriteLine();
            //}

            //problem 9
            // Select only the students from group 2

            var studentsFromGroup2 =
                from student in sampleStudents
                where student.GroupNumber == 2
                select student;

            // Order the students from group 2 by first name
            var orderedStudentsFromGroup2 =
                from student in studentsFromGroup2
                orderby student.FirstName
                select student;

            // Print students from Group2

            //Console.WriteLine("Students from group 2, ordered by first name (using LINQ):\n");

            //foreach (Student student in orderedStudentsFromGroup2)
            //{
            //    Console.WriteLine(student);
            //    Console.WriteLine();
            //}

            // problem 10: implement the same as above, using extension methods

            //Console.WriteLine("Students from group 2, ordered by first name (using extension methods):\n");
            var orderedStudents2 = sampleStudents.Where(x => x.GroupNumber == 2).OrderBy(x => x.FirstName);

            //foreach (Student student in orderedStudents2)
            //{
            //    Console.WriteLine(student);
            //    Console.WriteLine();
            //}

            #endregion

            #region Performing tasks from problems 11, 12, and 13

            // problem 11: extract all students w/ email in abv.bg using LINQ

            var studentsWithEmailsInAbv =
                from student in sampleStudents
                where student.Email.Contains("@abv.bg")
                select student;

            //Console.WriteLine("Students with emails in abv.bg:\n");

            //foreach (Student student in studentsWithEmailsInAbv)
            //{
            //    Console.WriteLine(student);
            //    Console.WriteLine();
            //}

            // problem 12: Extract all students w/ phones in Sofia, using LINQ

            var studentsWithPhonesInSofia =
                from student in sampleStudents
                where student.Tel.StartsWith("02") || student.Tel.StartsWith("+3592")
                select student;

            Console.WriteLine("Students with phones in Sofia:\n");

            foreach (Student student in studentsWithPhonesInSofia)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }

            // problem 13: Select all students that have at least one mark Excellent (6)
            // into a new anonymous class that has properties – FullName and Marks.

            var studentsWithExcellentMark =
                from student in sampleStudents
                where student.Marks.Contains((int) PossibleMarks.Excellent)
                select new
                {
                    FullName = student.FirstName + " " + student.LastName,
                    MarksList = student.Marks
                };

            Console.WriteLine("Students that have at least one excellent mark, each in new anonymous class with " +
                              "properties Fullname and MarksList:\n");

            foreach (var student in studentsWithExcellentMark)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.MarksList));
                Console.WriteLine();
            }
            #endregion

            #region Performing tasks from problems 14, 15 and 16

            // problem 14: Write down a similar program that extracts the students with exactly two marks "2".

            var studentsWithTwoTwos = sampleStudents.Where(x => x.Marks.FindAll(y => y == 2).Count == 2).
                Select(x => new {
                    FullName = x.FirstName + " " + x.LastName,
                    MarksList = x.Marks
                });

            Console.WriteLine("Students that have exactly two poor marks, each in new anonymous class with " +
                              "properties Fullname and MarksList:\n");

            foreach (var student in studentsWithTwoTwos)
            {
                Console.WriteLine("Full name: {0}", student.FullName);
                Console.WriteLine("Marks: {0}", string.Join(", ", student.MarksList));
                Console.WriteLine();
            }

            // problem 15: Extract all Marks of the students that enrolled in 2006. 
            // (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).

            var studentsFrom2006 = sampleStudents.Where(x => x.FN[4] == '0' && x.FN[5] == '6');
            var allMarksFrom2006 = new List<int>();

            foreach (var student in studentsFrom2006)
            {
                allMarksFrom2006.AddRange(student.Marks);
            }

            Console.WriteLine("All marks of the students, enrolled in 2006:\n{0}", string.Join(", ", allMarksFrom2006));
            Console.WriteLine();

            // problem 16: 

            Group group1 = new Group(1, "Mathematics");
            Group group2 = new Group(2, "Literature");
            Group group3 = new Group(3, "Computer Science");

            List<Group> groups = new List<Group>{group1, group2, group3};

            var studentsFromMathDpt =
                from someGroup in groups
                where someGroup.GroupNumber == 1
                join student in sampleStudents on someGroup.GroupNumber equals student.GroupNumber
                select new // creating new anonymous class after matching group numbers from the Student class 
                {          // and the Group class to get Name from the Student instances and department from the Group ones 
                    Name = student.FirstName + " " + student.LastName,
                    Department = someGroup.DepartmentName
                };

            Console.WriteLine("All students from mathematics department, extracted as new anonymous classes," +
                              " containing properties Name and Department:");

            foreach (var student in studentsFromMathDpt)
            {
                Console.WriteLine(student);
            }
            #endregion
        }
    }
}
