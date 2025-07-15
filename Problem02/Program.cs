using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Student(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
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
                new Student("Ahmed", "Hassan", "ahmed.hassan@gmail.com"),
                new Student("Omar", "Mahmoud", "omar.mahmoud@yahoo.com"),
                new Student("Mohamed", "Ali", "mohamed.ali@gmail.com"),
                new Student("Fatma", "Ibrahim", "fatma.ibrahim@hotmail.com"),
                new Student("Yasmin", "Abdel-Rahman", "yasmin.abdel@gmail.com")
            };

            /*
             * PROBLEM 2: Filter Students by Email Domain
             * 
             * Task: Print all students that have email @gmail.com in the order of appearance. Use LINQ.
             * 
             * Expected Output:
             * Ahmed Hassan
             * Mohamed Ali
             * Yasmin Abdel-Rahman
             */

            var result = students.Where(s => s.Email.EndsWith("@gmail.com"));
            //another solution
            var result2 = from s in students
                          where s.Email.EndsWith("@gmail.com")
                          select s;
            foreach (var student in result)    
                Console.WriteLine(student);

            Console.ReadKey();

        }
    }
}
