using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Difference__ToString_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a =1;
            string convert_a = Convert.ToString(a);
            string convert_a_ = a.ToString();
            Console.WriteLine($"Converted by Convert.ToString {convert_a}");
            Console.WriteLine($"Converted by ToString {convert_a_}" );

            object obj1 = null;
            string convert_obj = Convert.ToString(obj1);
            Console.WriteLine($"Converted by Convert.ToString {convert_obj}");
            string convert_obj_ = obj1.ToString();   //Gives an exception

            Console.WriteLine($"Converted by ToString {convert_obj_}");
            Console.ReadKey();


        }
    }
}
