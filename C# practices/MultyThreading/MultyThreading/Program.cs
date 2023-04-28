using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreading
{
    public class ThreadClass
    {
        public void ThreadMethod()
        {
            for (int i = 0;i< 10; i++)
            {
                Console.WriteLine("Thread 1 : " + i);
                Thread.Sleep(1000);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           ThreadClass threadClass = new ThreadClass();
            Thread thread = new Thread(new ThreadStart(threadClass.ThreadMethod));
            thread.Start();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread: " + i);
                Thread.Sleep(500);
            }
            Console.ReadKey();
        }
    }
}
