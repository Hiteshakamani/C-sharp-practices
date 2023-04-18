using System;
using System.Security.Cryptography.X509Certificates;

public class shape
{
    public virtual double Area_shape()
    {
        return 0;
    }
}

public class Rectangle : shape
{
    public double width { get; set; }
    public double height { get; set; }

    public override double Area_shape()
    {
        return width * height;
    }
}

public class Triangle : shape
{
    public double Base { get; set;}
    public double height { get; set; }

    public override double Area_shape()
{
    return (Base * height) / 2;
}
}

public class Circle : shape
{
    public double radius { get; set; }

    public override double Area_shape()
    {
        return 3.14 * radius * radius;
    }
}

public class shape_area
{
    public static double calculate_area(shape[] shapes)
    {
        double totalArea = 0;
        foreach (shape shape in shapes)
        {
            totalArea += shape.Area_shape();
        }
        return totalArea;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Rectangle rectangle = new Rectangle
        {
            width = 100,
            height = 100,
        };
        Triangle triangle = new Triangle
        {
            Base = 100,
            height = 30,
        };
        Circle circle = new Circle
        {
            radius = 100,
        };

        shape[] shapes = new shape[] {
            rectangle,triangle,circle,
        };

        double totalArea = shape_area.calculate_area(shapes);
            Console.WriteLine("Total Area :" + totalArea);
            
        

    }
}
