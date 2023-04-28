using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_method
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int first_even_num = Array.Find(arr1,delegate(int num) { return num % 2 == 0;});

            Console.WriteLine($"First even number is {first_even_num}");

            int sum = arr1.Sum(delegate (int num) { return num; });
            Console.WriteLine($"The sum of array : {sum}");

            Array.Sort(arr1,delegate (int a,int b) { return a.CompareTo(b); });

            Console.WriteLine("The sorted array is :");
            foreach(int i in arr1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
