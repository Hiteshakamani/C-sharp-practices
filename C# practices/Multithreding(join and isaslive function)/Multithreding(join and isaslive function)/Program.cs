using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreding_join_and_isaslive_function_
{
    internal class Program
    {
        static void method1()
        {
            Console.WriteLine("Method1 start...");
        }
        static void method2()
        {
            Console.WriteLine("Method2 start...");
        }
        static void method3()
        {
            Console.WriteLine("Method3 start...");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Main started...");

            Thread t1 = new Thread(Program.method1);
            t1.Start();
            Thread t2 = new Thread(Program.method2);
            t2.Start();
            Thread t3 = new Thread(Program.method3);
            t3.Start();

            t1.Join();
            Console.WriteLine("Method1 finish");

            t2.Join();
            Console.WriteLine("Method2 finish");

            t3.Join();
            Console.WriteLine("Method3 finish");

            Console.WriteLine("Main completed...");
            Console.ReadKey();

        }
    }
}
