using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class Program
    {
        static void PrintList(List<string> list)

        {
            foreach (string i in list)
            {
                Console.WriteLine(i);
            }
        }
        static void PrintList(List<int> list)
        {
            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            List<string> list = new List<string>();

            list.Add("Hitesha");
            list.Add("Hiren");
            list.Add("Hitanshi");

            Console.WriteLine("List :");
            PrintList(list);

            list.Insert(0, "ABC");
            Console.WriteLine("After insert element :");
            PrintList(list);

            int   a = list.Count;
            Console.WriteLine($"Count f the list : {a}");

            list.Remove("Hitanshi");
            Console.WriteLine("Afer removce Hitanshi : ");
            PrintList(list);

            list.RemoveAt(2);
            Console.WriteLine("\n after removing an element at index 2 :");
            PrintList(list);

            if (list.Contains("Hitesha"))
            {
                Console.WriteLine("Hitesha exists..!");
            }

            list.Sort();
            Console.WriteLine(" after sorting :");
            PrintList(list);

            list.Reverse();

            Console.WriteLine(" after reversing:");
            PrintList(list);

            int index = list.IndexOf("Hiren");

            Console.WriteLine("Index of Hiren in the list: " + index);

            list.Clear();

            Console.WriteLine(" after clearing:");
            PrintList(list);

            string[] addedList = { "Hardik", "Hitesh" };
            Console.WriteLine("Mix list and string :");
            list.AddRange(addedList);
            PrintList(list);


            Console.WriteLine("Mix list and string :");
            list.InsertRange(1,addedList);
            PrintList(list);


            List<int> nums = new List<int> { 1,6,7,9,6,4,3,7,9,03,4,2,2};
            int even = nums.Find(n => n % 2 == 0);
            Console.WriteLine("First even number: " + even);

            // Find all even numbers
            List<int> evens = nums.FindAll(n => n % 2 == 0);
            Console.Write("All even numbers: ");
            foreach (int n in evens)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            // Find the last even number 
            int lastEven = nums.FindLast(n => n % 2 == 0);
            Console.WriteLine("Last even number: " + lastEven);

            List<int> range = nums.GetRange(3, 5); 

            foreach (int number in range)
            {
                Console.WriteLine(number);
            }


            nums.RemoveRange(3, 5);
            foreach (int i in nums)
            {
                Console.WriteLine(i);
            }


            Console.WriteLine("Unsorted List:");
            PrintList(nums);

            nums.Sort(); //  list in ascending order

            Console.WriteLine("\nSorted List:");
            PrintList(nums);

            nums.Reverse(); // Reverse the order of the list

            Console.WriteLine("\nReverse Sorted List:");
            PrintList(nums);

            Console.ReadKey();



        }
    }
}
