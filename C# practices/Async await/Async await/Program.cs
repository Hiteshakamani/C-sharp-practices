using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_await
{
    class list
    {
       
        public static async Task<int> Multiplication (List<int> numbers)
        {
            await Task.Delay(5000);
            int result = numbers.Aggregate((a, b) => a * b);
            Console.WriteLine($"Multiplication result : {result}");
            return result;
        }
        public static async Task<int> Add(List<int> numbers)
        {
            await Task.Delay(5000);
            int result = numbers.Aggregate((a, b) => a + b);
            Console.WriteLine($"Addition result : {result}");
            return result;
        }

    }
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 45, 6, 7, 8, 9, 87 };
            Task<int> multi_result_task = list.Multiplication(numbers);
            int multi_result = await multi_result_task;
            Console.WriteLine("Multiplication result has been calculated: " + multi_result);

            Task<int> add_result_task = list.Add(numbers);
            int add_result = await add_result_task;
            Console.WriteLine("Addition result has been calculated: " + add_result);

            Console.ReadKey();
        }
    }
}
