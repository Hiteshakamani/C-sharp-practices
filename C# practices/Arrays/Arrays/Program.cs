using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Array.ForEach(numbers, num => Console.WriteLine(num));
            Console.WriteLine();

            int index = Array.IndexOf(numbers, 3);
            Console.WriteLine(index);

            Array.Reverse(numbers);
            Console.WriteLine(string.Join(",", numbers));
            Console.WriteLine();

            Array.Sort(numbers);
            Console.WriteLine(string.Join(",", numbers));
            Console.WriteLine();

            Array.Clear(numbers, 1, 3);
            Console.WriteLine(string.Join(",", numbers));
            Console.WriteLine();

            int[] destination = new int[3];
            Array.Copy(numbers, 1, destination, 0, 3);
            Console.WriteLine(string.Join(",", destination));
            Console.WriteLine();

            Array.Resize(ref numbers, 7);
            Console.WriteLine(string.Join(",", numbers));
            Console.WriteLine() ;

            Console.ReadKey();
        }
    }
}
