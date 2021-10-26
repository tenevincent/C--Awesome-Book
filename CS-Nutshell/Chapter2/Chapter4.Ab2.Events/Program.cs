using ConsoleDump;
using System;
using System.Collections.Generic;
using System.Net;

Foo(3);

void Foo(object obj)
{
    // C# won’t let you use the == operator, because obj is object.
    // However, we can use ‘is’
    if (obj is 3) Console.WriteLine("three");
}