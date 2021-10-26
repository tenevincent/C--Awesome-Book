using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Linq;

// CountWhitespaceDemo();


var result = Split("Word1 Word2 Word3".AsMemory());

 








IEnumerable<ReadOnlyMemory<char>> Split(ReadOnlyMemory<char> input)
{
    int wordStart = 0;
    for (int i = 0; i <= input.Length; i++)
        if (i == input.Length || char.IsWhiteSpace(input.Span[i]))
        {
            yield return input[wordStart..i];   // Slice with C# range operator
            wordStart = i + 1;
        }
}

void CountWhitespaceDemo()
{
    CountWhitespace("Word1 Word2").Dump();
    CountWhitespace("1 2 3 4 5".AsSpan(3, 3)).Dump();

    var span = "This ".AsSpan();                    // ReadOnlySpan<char>
    Console.WriteLine(span.StartsWith("This"));   // True
    Console.WriteLine(span.Trim().Length);         // 4
}

int CountWhitespace(ReadOnlySpan<char> s)
{
    int count = 0;
    foreach (char c in s)
        if (char.IsWhiteSpace(c))
            count++;
    return count;
}



void CopyToDemo()
{
    {
        Span<int> x = new[] { 1, 2, 3, 4 };
        Span<int> y = new int[4];
        x.CopyTo(y);
        //y.Dump("Copy");
    }

    {
        Span<int> x = new[] { 1, 2, 3, 4 };
        Span<int> y = new[] { 10, 20, 30, 40 };
        x[..2].CopyTo(y[2..]);                 // y is now { 10, 20, 1, 2 }
       // y.Dump("Copy - with span");
    }
}


void SpanDemo01()
{

    var numbers = new int[1000];
 


    for (int i = 0; i < numbers.Length; i++) numbers[i] = i;

    Sum(numbers).Dump("total - using implicit conversion");
    Sum(numbers.AsSpan()).Dump("total - using .AsSpan()");
    Sum(numbers.AsSpan(250, 500)).Dump("total - slicing");

    Span<int> span = numbers;
    Console.WriteLine(span[^1]);            // Last element
    Console.WriteLine(Sum(span[..10]));    // First 10 elements
    Console.WriteLine(Sum(span[100..]));   // 100th element to end
    Console.WriteLine(Sum(span[^5..]));    // Last 5 elements
} 


int Sum(ReadOnlySpan<int> numbers)
{
    int total = 0;
    foreach (int i in numbers) total += i;
    return total;
}

