using System;
using System.Collections.Generic;




List<int> numbers = null;
int? a = null;

(numbers ??= new List<int>()).Add(5);
Console.WriteLine(string.Join(" ", numbers));  // output: 5

numbers.Add(a ??= 0);
Console.WriteLine(string.Join(" ", numbers));  // output: 5 0
Console.WriteLine(a);  // output: 0

global::System.Console.WriteLine("Using global alias");


var now = new WeatherObservation
{
    RecordedAt = DateTime.Now,
    TemperatureInCelsius = 20,
    PressureInMillibars = 998.0m
};


string s1 = null; // Generates a compiler warning!
string? s2 = null; // OK: s2 is nullable reference type

Foo(s2);



(string Alpha, string Beta) namedLetters = ("a", "b");
Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");


Console.Clear();

ILogger.Log("This is a new message!");
(new Logger()).Log("message");



Console.ReadKey();


void Foo(string? s) => Console.Write(s?.Length);



public struct WeatherObservation
{
    public DateTime RecordedAt { get; init; }
    public decimal TemperatureInCelsius { get; init; }
    public decimal PressureInMillibars { get; init; }

    public override string ToString() =>
        $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
        $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
}




interface ILogger
{
   static void Log(string text) => Console.WriteLine(text + " from ILogger");
}


class Logger : ILogger {

   public  void Log(string text) => Console.WriteLine(text + " From Logger");


}
