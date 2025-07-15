using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<int> Grades { get; set; }

        public Student(string firstName, string lastName, int age, params int[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Grades = grades.ToList();
        }

        public double AverageGrade => Grades.Any() ? Grades.Average() : 0;

        public override string ToString()
        {
            return $"{FirstName} {LastName} (Age: {Age})";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Ahmed", "Hassan", 20, 85, 90, 78),
                new Student("Fatma", "Ibrahim", 19, 92, 88, 95),
                new Student("Omar", "Mahmoud", 21, 76, 82, 79),
                new Student("Yasmin", "Abdel-Rahman", 20, 88, 91, 87),
                new Student("Mohamed", "Ali", 22, 95, 89, 92)
            };

            /*
             * PROBLEM 13: Element Operations
             * 
             * Task A: Find the first student whose name starts with 'A' (First)
             * Task B: Find the last student who is older than 20 (Last)
             * Task C: Find the student at index position 2 (ElementAt)
             * Task D: Find the single student with age exactly 19 (Single)
             * Task E: Check if there's any student with age exactly 19 (Any)
             * Task F: Check if all students have grades (All)
             * 
             * Expected Output:
             * First with 'A': Ahmed Hassan (Age: 20)
             * Last older than 20: Mohamed Ali (Age: 22)
             * Student at index 2: Omar Mahmoud (Age: 21)
             * Single student age 19: Fatma Ibrahim (Age: 19)
             * Any age 19: True
             * All have grades: True
             */

             var firstWithA = students.FirstOrDefault(s => s.FirstName.StartsWith("A"));
             Console.WriteLine($"First with 'A': {firstWithA}");
             var lastOlderThan20 = students.LastOrDefault(s => s.Age > 20);
             Console.WriteLine($"\nLast older than 20: {lastOlderThan20}");
             var studentAtIndex2 = students.ElementAtOrDefault(2);
             Console.WriteLine($"\nStudent at index 2: {studentAtIndex2}");
             var singleAge19 = students.SingleOrDefault(s => s.Age == 19);
             Console.WriteLine($"\nSingle student age 19: {singleAge19}");
             var anyAge19 = students.Any(s => s.Age == 19);
             Console.WriteLine($"\nAny age 19: {anyAge19}");
             var allHaveGrades = students.All(s => s.Grades.Any());
             Console.WriteLine($"\nAll have grades: {allHaveGrades}");

            Console.ReadKey();
        }
    }
}
