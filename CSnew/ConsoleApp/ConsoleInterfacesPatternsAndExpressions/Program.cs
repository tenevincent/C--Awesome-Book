using ConsolePatternsIntroduction.Exceptions;
using System;

namespace ConsolePatternsIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                throw new DatabaseException("Db Connection Failed", "API DB");
            }
            catch (Exception err)
            {
                IReporter reporter = new Reporter();
                reporter.Report(err, "Something went wrong in the main method", SeverityLevel.Error);
            }
            Console.ReadKey();
        }
    }
}
