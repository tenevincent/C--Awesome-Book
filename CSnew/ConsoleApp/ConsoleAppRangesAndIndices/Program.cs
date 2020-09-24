using System;
using System.Linq;
using System.Text;

namespace ConsoleAppRangesAndIndices
{
    class Program
    {
        static void Main(string[] args)
        {
            testRanges();
            Console.ReadKey();


            Console.WriteLine("Hello World!");
        }


        private static void testRanges()
        {
            string[] letters = new string[]
            {
                "A", "B", "C", "D", "E", "F", "G", "H",
                "I", "J", "K", "L", "M", "N", "O", "P",
                "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
            };
            StringBuilder builder = new StringBuilder();
            Range range = 1..5;
            Range range2 = 10..^2;
            Range range3 =  ^2..;
            foreach (var letter in letters[range3])
            {
                builder.Append($"{letter} ");
            }
            Console.WriteLine(builder.ToString());
        }


    }
}
