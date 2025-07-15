using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacultyNumber { get; set; }
        public List<int> Marks { get; set; }

        public Student(string firstName, string lastName, string facultyNumber, params int[] marks)
        {
            FirstName = firstName;
            LastName = lastName;
            FacultyNumber = facultyNumber;
            Marks = marks.ToList();
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
                new Student("Ahmed", "Hassan", "554214", 6, 6, 6, 5),
                new Student("Omar", "Mahmoud", "653215", 3, 4, 5, 6),
                new Student("Mohamed", "Ali", "156212", 4, 2, 3, 4),
                new Student("Fatma", "Ibrahim", "234155", 5, 6, 5, 5),
                new Student("Yasmin", "Abdel-Rahman", "345189", 5, 3, 4, 2)
            };

            /*
             * PROBLEM 7: Students Enrolled in 2014 or 2015
             * 
             * Task: Using LINQ, extract and print the Marks of students that enrolled in 2014 or 2015.
             *       Students from 2014 have "14" as their 5th and 6th digit in FacultyNumber.
             *       Students from 2015 have "15" as their 5th and 6th digit in FacultyNumber.
             * 
             * Expected Output:
             * 6 6 6 5
             * 3 4 5 6
             */
             
             var EnrolledStudetns = students
                .Where(s => s.FacultyNumber.Substring(4, 2) == "14" || s.FacultyNumber.Substring(4, 2) == "15")
                .Select(s => s.Marks);
            foreach (var marks in EnrolledStudetns)
                Console.WriteLine(string.Join(" ", marks));
            
            Console.ReadKey();

        }
    }
}
