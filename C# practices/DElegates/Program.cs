using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DElegates
{
    public delegate void Message(string message);

    
    internal class Program
    {

        public static void showmessage(string message)
        {
            Console.WriteLine(message);
        }
        public static void hidemessage(string message)
        {
            Console.WriteLine("👿");
        }
        static void Main(string[] args)
        {
            Message messagedel;
            Console.WriteLine("Want meswsage ? ");

            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                messagedel = showmessage;
            }
            else
            {
                messagedel = hidemessage;
            }
            messagedel("Hiii....");
            Console.ReadKey();

        }


    }
}
