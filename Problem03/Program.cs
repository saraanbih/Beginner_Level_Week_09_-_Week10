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
                new Student("Yasmin", "Abdel-Rahman", 2),
                new Student("Abdel-Rahman", "El-Masry", 3),
                new Student("Nour", "Farouk", 3)
            };

            /*
             * PROBLEM 3: Name Length Filter
             * 
             * Task: Find students with FirstName longer than 5 characters. Order by FirstName length descending.
             * 
             * Expected Output:
             * Abdel-Rahman El-Masry (Length: 13)
             * Mohamed Ali (Length: 7)
             * Yasmin Abdel-Rahman (Length: 6)
             */

            var StudentsWithLongFirstName = students.Where(s => s.FirstName.Length > 5).
                OrderByDescending(s => s.FirstName.Length);
            foreach (var student in StudentsWithLongFirstName)
                Console.WriteLine($"{student} (Length: {student.FirstName.Length})");

            //another solution
            var StudentsWithLongFirstName2 = from student in students
                                             where student.FirstName.Length > 5
                                             orderby student.FirstName.Length descending
                                             select student;
            foreach (var student2 in StudentsWithLongFirstName2)
                Console.WriteLine($"{student2} (Length: {student2.FirstName.Length})");
            Console.ReadKey();
        }
    }
}


