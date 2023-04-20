using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exeption_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("enter a number : ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number : ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                if (num2 == 0)
                {
                    throw new DivideByZeroException();
                }


                double ans = (double)num1 / (double)num2;
                Console.WriteLine($"Answer : {ans}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter integer...!");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("can not divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Program executed");
            }
            Console.ReadKey();
        }
    }
}
