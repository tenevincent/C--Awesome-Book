using ConsoleDump;
using static System.Console;

// The signed integral types are sbyte, short, int, long:
int i = -1;
i.Dump();

int a = int.MinValue;
a--;
WriteLine(a == int.MaxValue);  // True

// The cost of this is that whenever you need a literal backslash, you must write it twice:
string a1 = "\\\\server\\fileshare\\helloworld.cs";
a1.Dump("a1");




Dude d1 = new Dude("John");
Dude d2 = new Dude("John");
WriteLine(d1 == d2);       // False
Dude d3 = d1;
WriteLine(d1 == d3);       // True

Max(2, 3).Dump();
Max(3, 2).Dump();


ReadKey();






int Max(int a, int b)
{
    return (a > b) ? a : b;
}





public class Dude
{
    public string Name;
    public Dude(string n) { Name = n; }
}