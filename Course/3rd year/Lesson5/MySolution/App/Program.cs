﻿using ShapeLibrary;
class Program
{
    public static void Main(string[] args)
    {
        Circle circle = new Circle(5);
        Console.WriteLine(circle.GetArea());
    }
}