namespace ShapeLibrary;


public class Circle : Shape
{
    double Radius { get; set; }


    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public double GetDiametr()
    {
        return 2 * Radius;
    }
}