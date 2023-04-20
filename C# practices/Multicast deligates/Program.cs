using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicast_deligates
{

    delegate void Delegate();

    internal class Program
    {
        static void method1()
        {
            Console.WriteLine("method 1");

        }
        static void method2()
        {
            Console.WriteLine("method 2");
        }
        static void method3()
        {
            Console.WriteLine("method 3");
        }
        static void Main(string[] args)
        {
            Delegate d = new Delegate(method1);
            d += method2;
            d += method3;

            d();
            Console.ReadKey();


        }

      
    }
}
