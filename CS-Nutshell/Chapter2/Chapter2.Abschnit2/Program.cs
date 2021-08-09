using ConsoleDump;
using System;
using System.Text;
using System.Linq;

Split("Stevie Ray Vaughan", out string a, out string b);
//Console.WriteLine(a);                      // Stevie Ray
//Console.WriteLine(b);                      // Vaughan

//Split("Stevie Ray Vaughan", out string x, out _);   // Discard the 2nd param
//Console.WriteLine(x);
//ExecuteNewExpression();
//DoNullCoalesionOperator();

// From C# 7, you can switch on multiple types.
//TellMeTheType(12);
//TellMeTheType("hello");
//TellMeTheType(true);

//DoExecuteIndices();



// ExecuteRanges();


int[,] matrix = new int[3, 3];  // 2-dimensional rectangular array
matrix.Dump();




void ExecuteRanges()
{
    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

    char[] firstTwo = vowels[0..2].Dump();     // 'a', 'e'
    char[] lastThree = vowels[2..].Dump();    // 'i', 'o', 'u'
    char[] middleOne = vowels[2..3].Dump();   // 'i'

    char[] lastTwo = vowels[^2..].Dump();     // 'o', 'u'

    Range firstTwoRange = 0..2;
    char[] firstTwo2 = vowels[firstTwoRange].Dump();   // 'a', 'e'
}

void DoExecuteIndices()
{
    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
    char lastElement = vowels[^1].Dump();   // 'u'
    char secondToLast = vowels[^2].Dump();   // 'o'
  
    Index first = 0;
    Index last = ^1;
    char firstElement = vowels[first].Dump();   // 'a'
    char lastElement2 = vowels[last].Dump();    // 'u'
}

void TellMeTheType(object objParam)   // object allows any type.
{
    switch (objParam)
    {
        case int index:
            Console.WriteLine("It's an int!");
            Console.WriteLine($"The square of {index} is {index * index}");
            break;
        case string str:
            Console.WriteLine("It's a string");
            Console.WriteLine($"The length of {str} is {str.Length}");
            break;
        default:
            Console.WriteLine("I don't know what x is");
            break;
    }
}



void DoNullCoalesionOperator()
{

    {
        string s1 = null;
        string s2 = s1 ?? "nothing";   // s2 evaluates to "nothing"
        s2.Dump();
    }
     
    {
        string s1 = null;
        s1 ??= "something";
        Console.WriteLine(s1);  // something

        s1 ??= "everything";
        Console.WriteLine(s1);  // something
    } 
}

void ExecuteNewExpression()
{
    StringBuilder sb = new();
    sb.Append("Add new data ");
    sb.Append("Add new data 2");
    Console.WriteLine(sb.ToString());
}

void Split(string name, out string firstNames, out string lastName)
{
    int i = name.LastIndexOf(' ');
    firstNames = name.Substring(0, i);
    lastName = name.Substring(i + 1);
}


