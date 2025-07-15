using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public List<int> Grades { get; set; }

        public Student(string firstName, string lastName, string city, params int[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Grades = grades.ToList();
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
                new Student("Ahmed", "Hassan", "Cairo", 85, 90, 78, 92),
                new Student("Fatma", "Ibrahim", "Alexandria", 92, 88, 95, 89),
                new Student("Omar", "Mahmoud", "Cairo", 76, 82, 79, 85),
                new Student("Yasmin", "Abdel-Rahman", "Giza", 88, 91, 87, 90),
                new Student("Mohamed", "Ali", "Alexandria", 95, 89, 92, 94),
                new Student("Nour", "El-Sayed", "Cairo", 82, 86, 84, 88)
            };

            /*
             * PROBLEM 14: Aggregate Operations
             * 
             * Task A: Calculate total number of students 
             * Task B: Find the average grade across all students and all subjects 
             * Task C: Find the highest single grade achieved by any student 
             * Task D: Find the lowest single grade achieved by any student 
             * Task E: Calculate the sum of all grades from Cairo students 
             * Task F: Use Aggregate to concatenate all student names
             * 
             * Expected Output:
             * Total Students: 6
             * Overall Average Grade: 87.2
             * Highest Grade: 95
             * Lowest Grade: 76
             * Cairo Total Grades: 982
             * All Names: Ahmed Hassan, Fatma Ibrahim, Omar Mahmoud, Yasmin Abdel-Rahman, Mohamed Ali, Nour El-Sayed
             */
             
             var totalStudents = students.Count;
            Console.WriteLine($"Total Students: {totalStudents}");
            var overallAverageGrade = students.SelectMany(s => s.Grades).Average();
            Console.WriteLine($"\nOverall Average Grade: {overallAverageGrade:F1}");
            var highestGrade = students.SelectMany(s => s.Grades).Max();
            Console.WriteLine($"\nHighest Grade: {highestGrade}");
            var lowestGrade = students.SelectMany(s => s.Grades).Min();
            Console.WriteLine($"\nLowest Grade: {lowestGrade}");
            var cairoTotalGrades = students.Where(s => s.City == "Cairo")
                                            .SelectMany(s => s.Grades)
                                            .Sum();
            Console.WriteLine($"\nCairo Total Grades: {cairoTotalGrades}");
            var AllNames = students.Select(s => s.ToString())
                                            .Aggregate((current, next) => current + ", " + next);
            Console.WriteLine($"\nAll Names: {AllNames}");

            Console.ReadKey();
        }
    }
}
