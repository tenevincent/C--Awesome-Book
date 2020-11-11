using System;

namespace ConsoleTupleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var employee = new Employee();
            employee.Note = ("Vincent",1);
        }
    }

    class Employee
    {

        public (string, double) Note { get; set; }

    }
}
