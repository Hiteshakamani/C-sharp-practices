using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock
{
    internal class Program
    {
        static object obj1 = new object();
        static object obj2 = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                lock (obj1)
                {
                    Console.WriteLine("lock 1");
                    Thread.Sleep(1000);
                    Console.WriteLine("t1 is waiting for lock 2 ...");
                    lock (obj2)
                    {
                        Console.WriteLine("t1 accuired lock 2");
                    }
                }
            });

            Thread t2 = new Thread(() =>
            {
                lock (obj1)
                {
                    Console.WriteLine("lock 2");
                    Thread.Sleep(1000);
                    Console.WriteLine("t2 is waiting for lock 1 ...");
                    lock (obj2)
                    {
                        Console.WriteLine("t2 accuired lock 1");
                    }
                }
            });
            t1.Start();
            t2.Start();
            t2.Join();
            t2.Join();

            Console.WriteLine("Finish");
        }
    }
}
