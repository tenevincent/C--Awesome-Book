using ConsoleDump;
using System;




// To call the deconstructor, we use the following special syntax:
Rectangle rect = new(3, 4);
(var width, var height) = rect;          // Deconstruction
Console.WriteLine(width + " " + height);    // 3 4

// We can also use implicit typing:  
var (x, y) = rect;          // Deconstruction
Console.WriteLine(x + " " + y);

// If the variables already exist, we can do a *deconstructing assignment*:
(x, y) = rect;
Console.WriteLine(x + " " + y);

class Rectangle
{
    public readonly float Width, Height;

    public Rectangle(float width, float height)
    {
        Width = width;
        Height = height;
    }

    ~Rectangle()
    {

    }

 

    public void Deconstruct(out float width, out float height)
    {
        width = Width;
        height = Height;
    }
}