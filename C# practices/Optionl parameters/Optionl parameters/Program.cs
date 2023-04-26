using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Optionl_parameters
{

    internal class Program
    {
        //Method overloading
        public static void Add(int num1, int num2)
        {
            Add(num1, num2, null);
        }

        public static void Add(int num1, int num2,  int[] nums)
        {
            int result= num1 + num2 ;
            if(nums != null )
            {
                foreach (int num in nums)
                {
                    result += num;
                }  
            }
            Console.WriteLine("Sum = " + result);
        }

        //Specifying Parameter Defaults:
        public static void AddOne(int num1, int num2, int[] nums = null)
        {
            int result = num1 + num2;
            if (nums != null)
            {
                foreach (int num in nums)
                {
                    result += num;
                }
            }
            Console.WriteLine("Sum = " + result);
        }

        //Using OptionalAttribute:
        public static void AddTwo(int num1, int num2, [Optional] int[] nums)
        {
            int result = num1 + num2;
            if (nums != null)
            {
                foreach (int num in nums)
                {
                    result += num;
                }
            }
            Console.WriteLine("Sum = " + result);
        }


        static void Main(string[] args)
        {
            Add(12, 32);
            Add(12, 32, new int[] {23,43,43});
            AddOne(12,23);
            AddTwo(12,23);
        }
    }
}
