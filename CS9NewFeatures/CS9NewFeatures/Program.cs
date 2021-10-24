using System;
using System.Collections.Generic;

namespace CS9NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

            var student = new Student()
            {
                FirstName = "Jared",
                LastName = "Parosns",
            };
            // student.LastName = "Parsons"; // Error: LastName is not settable

            Student st = new() { FirstName = "Vincent", LastName = "", Names = new List<string>() };


            Console.ReadKey();

        }
    }


    class Student
    {
        public string FirstName { get; init; }
        public string LastName { get; init; } = default;

        public List<string> Names { get; set; } = new List<string>();
    }
}
