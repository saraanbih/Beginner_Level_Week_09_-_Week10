using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupNumber { get; set; }

        public Student(string firstName, string lastName, int groupNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            GroupNumber = groupNumber;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Ahmed", "Hassan", 1),
                new Student("Omar", "Mahmoud", 2),
                new Student("Mohamed", "Ali", 1),
                new Student("Fatma", "Ibrahim", 2),
                new Student("Yasmin", "Abdel-Rahman", 2)
            };

            /*
             * PROBLEM 1: Students by Group
             * 
             * Task: Print all students from group number 2. Use LINQ. Order the students by FirstName.
             * 
             * Expected Output:
             * Fatma Ibrahim
             * Omar Mahmoud
             * Yasmin Abdel-Rahman
             */

            //My Solution
            var AllStudentsFromGroup2_1 = students.Where(s => s.GroupNumber == 2).OrderBy(s => s.FirstName);
            foreach (var student1 in AllStudentsFromGroup2_1) // Renamed 'student' to 'student1'
                Console.WriteLine(student1);

            //another solution
            var AllStudentsFromGroup2_2 = from student in students
                                          where student.GroupNumber == 2 // Fixed incorrect syntax
                                          orderby student.FirstName // Fixed incorrect syntax
                                          select student;
            foreach (var student2 in AllStudentsFromGroup2_2) // Renamed 'student' to 'student2'
                Console.WriteLine(student2);

            Console.ReadKey();
        }
    }
}
