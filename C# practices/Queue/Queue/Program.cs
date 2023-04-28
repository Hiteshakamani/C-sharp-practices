using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine("Total elements in queue : ");
            Console.WriteLine(queue.Count);

            Console.WriteLine("Elements in queue : ");
            foreach(int i in queue)
            {
                Console.WriteLine(i);
            }

            int dequeue = queue.Dequeue();
            Console.WriteLine($"Dequeue item : {dequeue}");

            int peek = queue.Peek();
            Console.WriteLine($"Peeked item : {peek}");

            bool containItem = queue.Contains(peek);
            Console.WriteLine($"Contains peeked element ? {peek}");

            queue.Clear();

            bool isEmpty = queue.Count == 0;
            Console.WriteLine($"Queue is empty ? {isEmpty}");
            Console.ReadKey();
        }
    }
}
