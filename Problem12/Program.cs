using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cairoStudents = new List<string>
            {
                "Ahmed Hassan",
                "Fatma Ibrahim",
                "Omar Mahmoud",
                "Yasmin Abdel-Rahman",
                "Mohamed Ali"
            };

            List<string> alexandriaStudents = new List<string>
            {
                "Omar Mahmoud",
                "Nour El-Sayed",
                "Yasmin Abdel-Rahman",
                "Khaled Farouk",
                "Amr Mostafa"
            };

            List<string> gizaStudents = new List<string>
            {
                "Ahmed Hassan",
                "Nour El-Sayed",
                "Abdel-Rahman El-Masry"
            };

            /*
             * PROBLEM 12: Set Operations
             * 
             * Task A: Find students who are in both Cairo and Alexandria (Intersect)
             * Task B: Find all unique students from all cities (Union)
             * Task C: Find students who are in Cairo but not in Alexandria (Except)
             * Task D: Remove duplicate names from Cairo students list (Distinct)
             * 
             * Expected Output:
             * Intersection (Cairo ∩ Alexandria):
             * Omar Mahmoud
             * Yasmin Abdel-Rahman
             * 
             * Union (All unique students):
             * Ahmed Hassan
             * Fatma Ibrahim
             * Omar Mahmoud
             * Yasmin Abdel-Rahman
             * Mohamed Ali
             * Nour El-Sayed
             * Khaled Farouk
             * Amr Mostafa
             * Abdel-Rahman El-Masry
             * 
             * Cairo Except Alexandria:
             * Ahmed Hassan
             * Fatma Ibrahim
             * Mohamed Ali
             */

             var Intersection = cairoStudents.Intersect(alexandriaStudents);
             Console.WriteLine("Intersection (Cairo ∩ Alexandria):");
             foreach (var student in Intersection) 
                 Console.WriteLine(student);

             var Union = cairoStudents.Union(alexandriaStudents).Union(gizaStudents);
             Console.WriteLine("\nUnion (All unique students):");
             foreach (var student in Union) 
                 Console.WriteLine(student);

             var CairoExceptAlexandria = cairoStudents.Except(alexandriaStudents);
             Console.WriteLine("\nCairo Except Alexandria:");
             foreach (var student in CairoExceptAlexandria) 
                 Console.WriteLine(student);

             var RemoveDuplicates = cairoStudents.Distinct();
             Console.WriteLine("\nCairo Students without duplicates:");
             foreach (var student in RemoveDuplicates) 
                 Console.WriteLine(student);

            Console.ReadKey();
        }
    }
}
