using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_implementation
{
    public interface IShape
    {
        void Draw();
    }

    public interface IColor
    {
        void Draw();
    }

    public class Rectangle : IShape, IColor
    {
        void IShape.Draw()
        {
            Console.WriteLine("Shape is Rectangle");
        }
        void IColor.Draw() 
        {
            Console.WriteLine("Color is red");
        }

    }
    public class Triangle : IShape,IColor
    {
        void IShape.Draw()
        {
            Console.WriteLine("Shape is Triangle");
        }
        void IColor.Draw()
        {
            Console.WriteLine("Color is yellow");
        }

    }
    public class Circle : IShape,IColor
    {
        void IShape.Draw()
        {
            Console.WriteLine("Shape is Circle");
        }
        void IColor.Draw()
        {
            Console.WriteLine("Color is red");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IShape rect = new Rectangle();
            rect.Draw();

            IColor rect1 = new Rectangle();
            rect1.Draw();

            IShape tri = new Triangle();
            tri.Draw();

            IColor tri1 = new Triangle();
            tri1.Draw();

            IShape cir = new Circle();
            cir.Draw();

            IColor cir1 = new Circle();
            cir1.Draw();

            Console.ReadKey();
        }
    }
}
