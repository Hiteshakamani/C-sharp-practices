using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    internal class Program
    {
        public class class1
        {
            [Obsolete("This method is obsolete. Use NewMethod() instead.")]
            public static void OldMethod()
            {
                Console.WriteLine("This is the old method");
            }

            public static void NewMethod()
            {
                Console.WriteLine("This is the updated method");
            }

        }
        static void Main(string[] args)
        {
           class1.NewMethod();

        }

    }
}
