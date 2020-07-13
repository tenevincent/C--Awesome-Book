using System;
using System.Collections.Generic;
using System.Linq;

namespace ImmutableStructs
{
    class Program
    {
        static void Main(string[] args)
        {


            var newGuid = Guid.Parse("2a2f376f-07ea-4c53-8f50-4386eaa6ad00");


            Dictionary<string, int> dict = new Dictionary<string, int>();

            dict.Add("keyboard", 1);
            dict.Add("mouse", 2);
          
            var val = dict.Keys.ToList();



            Console.WriteLine(default(int));  // output: 0
            Console.WriteLine(default(object) is null);  // output: True
            Console.WriteLine("Default Program output: " + default(Program));  // output: 0


            Method1();

            // Point nullValue = null; // will not compile
            Point defaultValue = default(Point); // will set all fields to default value
            var x = defaultValue.X; // will set x to 0
            var y = defaultValue.Y; // will set y to 0
            Console.WriteLine($"x = {x}, y = {y}");

            defaultValue = new Point(); // equivalent to default(Point)
            Console.WriteLine($"x = {defaultValue.X}, y = {defaultValue.Y}");

            Console.ReadLine();
        }

        static void Method1()
        {
            var a = new Point();
            Console.WriteLine($"Method1 - start: x = {a.X}, y = {a.Y}");
            a = Method2(a);
            Console.WriteLine($"Method1 - end: x = {a.X}, y = {a.Y}");
        }

        static Point Method2(Point a)
        {
            Console.WriteLine($"Method2 - start: x = {a.X}, y = {a.Y}");
            // a.X = 1; // will not compile
            a = new Point(1, a.Y);
            Console.WriteLine($"Method2 - end: x = {a.X}, y = {a.Y}");
            return a;
        }

    }
}
