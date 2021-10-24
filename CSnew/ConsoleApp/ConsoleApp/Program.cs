using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Email { get; set; }
        public double Gpa { get; set; }

    }

    class Program
    {



        async static Task Main(string[] args)
        {
            Console.ForegroundColor =ConsoleColor.Green;

            {
                Student student = null;
                Console.WriteLine($"Student {student?.FirstName} {student?.LastName.ToLower()} has a GPA of {student?.Gpa}");
            }


            await foreach (var studentItem in GetStudentsAsync())
            {
                Console.WriteLine($"{studentItem.FirstName} {studentItem.LastName}");
            }


            var message = "Hello World!";
            Console.WriteLine(message);
            Console.ReadKey();
        }


        async static IAsyncEnumerable<Student> GetStudentsAsync()
        {
            var list = new List<Student>()
            {
                new Student() {FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Gpa = 2.98},
                new Student() {FirstName = "Elizabeth", LastName = "Cooper", Email="elizabeth@outlook.com", Gpa = 3.5},
                new Student() {FirstName = "Mike", LastName = "Olson", Email = "mike@gmail.com", Gpa = 3.22}
            };




            foreach (var student in list)
            {
                await Task.Delay(2000);
                yield return student;
            }
        }


    }
}
