using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Difference_Stringbuilder_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string usestring = "c#";
            usestring += "video";
            usestring += "tutorial";
            usestring += "for";
            usestring += "beginners";
            Console.WriteLine(usestring);

            StringBuilder userstring = new StringBuilder("Heyy");
            userstring.Append("how");
            userstring.Append("beautiful");
            userstring.Append("is");
            userstring.Append("this!");
            Console.WriteLine(userstring.ToString());
            Console.ReadKey();
        }
    }
}
