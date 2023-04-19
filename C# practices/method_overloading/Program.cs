using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace method_overloading
{

    public class Calculator
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Add(int x, int y, int z)
        {
            return x + y + z;
        }

        public int Add(int w, int x, int y, int z)
        {
            return w + x + y + z;
        }

        public int Add(params int[] x)
        {
            int sum = 0;
            foreach(int i in x)
            {
                sum += i;
            }
            return sum;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Add(params double[] x)
        {
            double sum = 0;
            foreach (double i in x)
            {
                sum += i;
            }
            return sum;
        }

        public string Add(string x , int y)
        {
            return x + y.ToString();
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator c1 = new Calculator();
            int add = c1.Add(1, 2);
            int add1 = c1.Add(1, 2, 3);
            int add2 = c1.Add(1, 2, 3, 4);

            int[] arr = {1,2,3,4,5,67,8,9};
            int add3 = c1.Add(arr);

            double add4 = c1.Add(2.3,44.5);

            double[] arr1 = { 1, 2, 3, 4, 54.678, 43.65 };
            double add5 = c1.Add(arr1);

            string str = "abc";
            string add6 = c1.Add(str, 12121);

            Console.WriteLine($"method answer : {add}");
            Console.WriteLine($"method 1 answer : {add1}");
            Console.WriteLine($"method 2 answer : {add2}");
            Console.WriteLine($"method 3 answer : {add3}");
            Console.WriteLine($"method 4 answer : {add4}");
            Console.WriteLine($"method 5 answer : {add5}");
            Console.WriteLine($"method 6 answer : {add6}");
            Console.ReadKey(); 


        }
    }
}
