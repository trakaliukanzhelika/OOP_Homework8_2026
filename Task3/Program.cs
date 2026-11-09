// Порушено принцип заміщення Лісков (LSP).

using System;

interface IShape
{
    int GetArea();
}

class Rectangle : IShape
{
    public int Width { get; }
    public int Height { get; }

    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public int GetArea() { return Width * Height; }
}

class Square : IShape
{
    public int Side { get; }

    public Square(int side)
    {
        Side = side;
    }

    public int GetArea() { return Side * Side; }
}

class Program
{
    static void Main(string[] args)
    {
        IShape rect = new Rectangle(5, 10);
        IShape square = new Square(5);

        Console.WriteLine(rect.GetArea());
        Console.WriteLine(square.GetArea());
    }
}
