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
                new Student("Sara", "Mills", "554214", 6, 6, 6, 5),
                new Student("Andrew", "Gibson", "653215", 3, 4, 5, 6),
                new Student("Craig", "Ellis", "156212", 4, 2, 3, 4),
                new Student("Steven", "Cole", "234155", 5, 6, 5, 5),
                new Student("Andrew", "Carter", "345189", 5, 3, 4, 2)
            };

            // PROBLEM 9: Students Enrolled in 2014 or 2015
            // Task: Using LINQ, extract and print the Marks of the students that enrolled in 2014 or 2015
            //       (the students from 2014 have 14 as their 5-th and 6-th digit in the FacultyNumber,
            //       those from 2015 have 15).
            // 
            /* Expected Output:
                 Marks     
                6 6 6 5       
                3 4 5 6       
            */
            
            var EnrolleddStudents = students
                .Where(s => s.FacultyNumber.Substring(4, 2) == "14" || s.FacultyNumber.Substring(4, 2) == "15")
                .Select(s => s.Marks);
            foreach (var marks in EnrolleddStudents)
                Console.WriteLine(string.Join(" ", marks));
            
            Console.ReadKey();
        }
    }
}
