using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreding_Threadstart_delegate_
{
    internal class Program
    {
        static void Print()
        {
            for (int i = 0; i <10;i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            ThreadStart thread_start = new ThreadStart(Print);
            Thread thread = new Thread(thread_start);
            thread.Start();

            for (int i = 0;i <10;i++)
            {
                Console.WriteLine("This is the main thread....");
                Thread.Sleep(5000);

            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
