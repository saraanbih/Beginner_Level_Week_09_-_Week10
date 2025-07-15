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
        public string City { get; set; }
        public List<int> Grades { get; set; }

        public Student(string firstName, string lastName, int age, string city, params int[] grades)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            City = city;
            Grades = grades.ToList();
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public double AverageGrade => Grades.Any() ? Grades.Average() : 0;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student("Ahmed", "Hassan", 20, "Cairo", 85, 92, 78, 90),
                new Student("Omar", "Mahmoud", 22, "Alexandria", 88, 76, 94, 82),
                new Student("Mohamed", "Ali", 19, "Cairo", 92, 88, 85, 91),
                new Student("Fatma", "Ibrahim", 21, "Giza", 79, 84, 77, 80),
                new Student("Yasmin", "Abdel-Rahman", 20, "Alexandria", 95, 89, 93, 96),
                new Student("Khaled", "Farouk", 23, "Cairo", 72, 68, 75, 71),
                new Student("Nour", "El-Sayed", 19, "Giza", 87, 91, 83, 89),
                new Student("Amr", "Mostafa", 22, "Alexandria", 81, 85, 79, 83)
            };

            /*
             * PROBLEM 10: Top Performing Students by City
             * 
             * Task: Find the top 2 students with highest average grades from each city.
             *       Display their name, city, and average grade (rounded to 1 decimal place).
             *       Order results by city name, then by average grade descending.
             * 
             * Expected Output:
             * Alexandria:
             *   Yasmin Abdel-Rahman - Average: 93.2
             *   Omar Mahmoud - Average: 85.0
             * Cairo:
             *   Mohamed Ali - Average: 89.0
             *   Ahmed Hassan - Average: 86.2
             * Giza:
             *   Nour El-Sayed - Average: 87.5
             *   Fatma Ibrahim - Average: 80.0
             */

            var TopStudentsByCity = students
                .GroupBy(s => s.City)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    City = g.Key,
                    TopStudents = g.OrderByDescending(s => s.AverageGrade).Take(2)
                    .Select(s => new
                    {
                        Name = s.ToString(),
                        AverageGrade = Math.Round(s.AverageGrade, 1)
                    })
                });
            foreach (var cityGroup in TopStudentsByCity){
                Console.WriteLine($"{cityGroup.City}:");
                foreach (var student in cityGroup.TopStudents)
                {
                    Console.WriteLine($"  {student.Name} - Average: {student.AverageGrade}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
