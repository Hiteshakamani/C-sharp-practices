using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multithreading_Parameterize_threadstart_delegate_
{
    internal class Program
    {
        static void Method1(object o1)
        {
            int num = (int)o1;
            Console.WriteLine($"{num} ~ started");
            Thread.Sleep(1000);
            Console.WriteLine($"{num} ~ ended");
        }
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Thread[] threads = new Thread[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(Method1));
                threads[i].Start(arr[i]);
            }
            foreach(var thread in threads)
            {
                thread.Join();
            }

            Console.ReadKey();
        }
    }
}
