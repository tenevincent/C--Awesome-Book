using ConsoleDump;
using System;


Transformer t = Square;          // Create delegate instance
t += Rectangle;
t += Rectangle;

t(2).Dump();

//int result = t(3);               // Invoke delegate
//Console.WriteLine(result);      // 9

DoShowDelegate();

int Square(int x)  { Console.WriteLine("Square"); return x* x; }
int Rectangle(int x) { Console.WriteLine("Rectangle"); return x * x; }


void SomeMethod1() => "SomeMethod1".Dump();
void SomeMethod2() => "SomeMethod2".Dump();

void DoShowDelegate()
{
    SomeDelegate d = SomeMethod1;
    d += SomeMethod2;

    d();
    " -- SomeMethod1 and SomeMethod2 both fired\r\n".Dump();

    d -= SomeMethod1;
    d();
    " -- Only SomeMethod2 fired".Dump();
}

delegate int Transformer(int x);   // Our delegate type declaration




delegate void SomeDelegate();