using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CourseId { get; set; }

        public Student(int id, string firstName, string lastName, int courseId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            CourseId = courseId;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }

        public Course(int id, string name, string instructor)
        {
            Id = id;
            Name = name;
            Instructor = instructor;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student(1, "Ahmed", "Hassan", 101),
                new Student(2, "Fatma", "Ibrahim", 102),
                new Student(3, "Omar", "Mahmoud", 101),
                new Student(4, "Yasmin", "Abdel-Rahman", 103),
                new Student(5, "Mohamed", "Ali", 102)
            };

            List<Course> courses = new List<Course>
            {
                new Course(101, "Computer Science", "Dr. Amr Mostafa"),
                new Course(102, "Mathematics", "Dr. Nour El-Sayed"),
                new Course(103, "Physics", "Dr. Khaled Farouk")
            };

            /*
             * PROBLEM 11: Join Operations
             * 
             * Task: Join students with their courses and display student name with course name and instructor.
             *       Order by course name, then by student first name.
             * 
             * Expected Output:
             * Ahmed Hassan - Computer Science (Dr. Amr Mostafa)
             * Omar Mahmoud - Computer Science (Dr. Amr Mostafa)
             * Fatma Ibrahim - Mathematics (Dr. Nour El-Sayed)
             * Mohamed Ali - Mathematics (Dr. Nour El-Sayed)
             * Yasmin Abdel-Rahman - Physics (Dr. Khaled Farouk)
             */

            var result = students.Join(courses, s => s.CourseId, c => c.Id,
                         (s, c) => new
                         {
                             CourseName = c.Name,
                             StudentName = s.FirstName + " " + s.LastName,
                             InstructorName = c.Instructor
                         }).OrderBy(x => x.CourseName)
                         .ThenBy(x => x.StudentName);
            foreach (var student in result)
                Console.WriteLine($"{student.StudentName} - {student.CourseName} ({student.InstructorName})");

            //another way to solve it
            var result2 = from s in students
                          join c in courses on s.CourseId equals c.Id
                          orderby c.Name, s.FirstName
                          select new
                          {
                              CourseName = c.Name,
                              StudentName = s.FirstName + " " + s.LastName,
                              InstructorName = c.Instructor
                          };
            foreach (var student in result2)
                Console.WriteLine($"{student.StudentName} - {student.CourseName} ({student.InstructorName})");

            Console.ReadKey();
                           



        }
    }
}
