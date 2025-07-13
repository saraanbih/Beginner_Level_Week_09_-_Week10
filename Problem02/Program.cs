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

            //The Same as Problem01/Program.cs

        }
    }
}
