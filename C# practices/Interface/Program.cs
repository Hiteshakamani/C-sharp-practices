using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IMovable
    {
        void Move(int x, int y);
    }

    public class car : IMovable
    {
        public void Move(int x, int y)
        {
            Console.WriteLine($"Car moved to ({x},{y}) from the point (0,0)");
        }
    }

    public class bike : IMovable
    {
        public void Move(int x, int y)
        {
            Console.WriteLine($"Bike moved to ({x},{y}) from the point (0,0)");
        }
    }
    public class cycle : IMovable
    {
        public void Move(int x, int y)
        {
            Console.WriteLine($"Cycle moved to ({x},{y}) from the point (0,0)");
        }
    }


    internal class Program
    {  
    
        static void Main(string[] args)
        {
            IMovable car = new car();
            car.Move(100, 200);
            IMovable bike = new bike();
            bike.Move(10, 12);
            IMovable  cycle = new cycle();
            cycle.Move(5, 3);
            Console.ReadKey();

        }
    }
}
