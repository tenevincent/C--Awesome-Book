using System;
using ConsolePatternsSwitchExp.Exceptions;

namespace ConsolePatternsSwitchExp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new HttpException("Oops, not found!", "http://api.com/route", 404);
                //throw new HttpException("oops, it's our fault", "http://api.com/route", 500);
                //throw new HttpException("oops, it's our fault", "http://api.com/route", 503);
            }
            catch (Exception err)
            {
                IReporter reporter = new Reporter();
                reporter.Report(err, "error detected in main method", SeverityLevel.Warning);
            }
            Console.ReadKey();
        }
    }
}
