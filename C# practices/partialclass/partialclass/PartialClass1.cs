using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partialclass
{
    internal partial class Program
    {
        private int num1;

        public void setValue (int Num1)
        {
            this .num1 = Num1;
        }
        public void display()
        {
            Console.WriteLine($"Number1 : {num1}");
        }
    }
}
