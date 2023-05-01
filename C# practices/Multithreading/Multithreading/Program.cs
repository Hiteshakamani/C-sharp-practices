using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Multithreading
{
    internal class Program
    {
       static  int total = 0;
        static object _lock = new object();

        static void Method1()
        {
            //for (int i = 1; i <= 10000; i++)
            //{
            //    Interlocked.Increment(ref total);
            //}

            for (int i = 1; i <= 10000; i++)
            {
                lock (_lock)
                {
                    total++;
                }
            }
        }
        static void Main(string[] args)
        {
           
           Thread t1 = new Thread(Program.Method1);
            Thread t2 = new Thread(Program.Method1);
            Thread t3 = new Thread(Program.Method1);

            t1.Start(); t2.Start(); t3.Start();
            t1.Join(); t2.Join(); t3.Join();

            Console.WriteLine($"Total is : {total}");
            Console.ReadKey();

        }
    }
}
