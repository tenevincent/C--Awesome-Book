using System;


object x = 4;

switch (x)
{
    case int i:
        Console.WriteLine("It's an int!");
        break;
    case string s:
        Console.WriteLine(s.Length); // We can use the s variable
        break;
    case bool b when b == true: // Matches only when b is true
        Console.WriteLine("True");
        break;
    case null:
        Console.WriteLine("Nothing");
        break;
}


string GetWeightCategory(decimal bmi) => bmi switch
{
    < 18.5m => "underweight",
    < 25m => "normal",
    < 30m => "overweight",
    _ => "obese"
};
