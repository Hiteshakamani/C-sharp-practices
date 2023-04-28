using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> num = new Stack<int>();

            num.Push(1);
            num.Push(2);
            num.Push(3);
            num.Push(4);
            num.Push(5);

            Console.WriteLine($"Total elements in stack : {num.Count}");

            int top = num.Peek();
            Console.WriteLine($"Last element added in the stack : {top}");

            int poped_num = num.Pop();
            Console.WriteLine($"Poped item in num : {poped_num}");

            bool has_item = num.Contains(3);
            Console.WriteLine($"The element 3  is in the queue ? {has_item}");

            int[] num_Array = num.ToArray();
            Console.WriteLine("Converted from stack to queue :");
            foreach( int item in num_Array )
            {
                Console.WriteLine(item);
            }

            num.Clear();
            Console.WriteLine($"Stack is cleaned : {num}");
            Console.ReadKey();


        }
    }
}
