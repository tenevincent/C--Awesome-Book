using ConsoleDump;
using System;

ILogger.Prefix = "File log: ";



ValueTuple<string, int> bob1 = ValueTuple.Create("Bob", 23);



(string, int) bob2 = ValueTuple.Create("Bob", 23);
(string name, int age) bob3 = ValueTuple.Create("Bob", 23);




var logger = new Logger();

// We can't call the Log method directly:
// foo.Log ("message")   // Won't compile

// But we can call it via the interface:
//if(logger is ILogger log)
//    log.Log("This is a new message!");


ILogger.Log("This is a new message!");

interface ILogger
{
    static string Prefix = "";

    static void  Log(string text) => Console.WriteLine(text);
}

class Logger : ILogger
{
    // We don't need to implement anything
}