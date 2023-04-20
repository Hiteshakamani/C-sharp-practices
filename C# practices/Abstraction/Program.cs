using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Abstraction
{
    public abstract class Vehical
    {
        public string Name { get; set; }
        public double Speed { get; set; }

        public Vehical(string name , double speed) 
        { 
            Name = name;
            Speed = speed;
        }

        public abstract void Move();
    }

    public class car : Vehical
    {
        public car (string name, double speed): base (name, speed)
        { 
            
        }

        public override void Move()
        {
            Console.WriteLine($"{Name} has speed {Speed}");
        }

    }

    public class bike : Vehical
    {
        public bike(string name, double speed) : base(name, speed)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{Name} has speed {Speed}");
        }

    }
    public class cycle : Vehical
    {
        public cycle(string name, double speed) : base(name, speed)
        {

        }

        public override void Move()
        {
            Console.WriteLine($"{Name} has speed {Speed}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehical car = new car("BMW", 110.45);
            Vehical bike = new bike("Splender", 60.324);
            Vehical cycle = new cycle("abc", 50.783);

            car.Move();
            bike.Move();
            cycle.Move();

            
            Console.ReadKey();
        }
    }
}
