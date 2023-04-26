using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace partialclass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PartialClass1.a = new PartialClass1();
            a.setValue(55);
            if (a.isInt())
            {
                args.display();
            }
            else
            {
                Console.WriteLine("Not valid ..!");
            }

        }
    }
}
