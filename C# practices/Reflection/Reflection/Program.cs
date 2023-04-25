using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    internal class Program
    {

        public class Car
        {
            public string Name { get; set; }
            public int Speed { get; set; }

            public void CarInfo()
            {
                Console.WriteLine($"This car name is {Name} and its speed is {Speed} .");
            }
        }
        static void Main(string[] args)
        {
            //Type carType = typeof(Car);
            //object car = Activator.CreateInstance(carType);

            //PropertyInfo nameProperty = car.GetType().GetProperty("Name");


            Type carType = typeof(Car);
            object car = Activator.CreateInstance(carType);

            PropertyInfo nameProperty = carType.GetProperty("Name");
            nameProperty.SetValue(car, "BMW");

            PropertyInfo speedProperty = carType.GetProperty("Speed");
            speedProperty.SetValue(car, 130);

            MethodInfo carInfo = carType.GetMethod("CarInfo");
            carInfo.Invoke(car, null);

            Console.ReadKey();
        }
    }
}
