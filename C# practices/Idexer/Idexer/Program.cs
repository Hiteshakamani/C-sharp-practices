using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idexer
{
    public class Class1 : IEnumerable<string>
    {
        private string[] fruits = new string[4];

        public string this[int index]
        {
            get
            {
                return (index >= 0 && index < fruits.Length) ? fruits[index] : "";
            }
            set
            {
                if (index >= 0 && index < fruits.Length)
                {
                    fruits[index] = value;
                }
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string fruit in fruits)
            {
                yield return fruit;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 fruit = new Class1();
            fruit[0] = "mango";
            fruit[1] = "apple";
            fruit[2] = "kiwi";
            fruit[3] = "banana";

            Console.WriteLine("print using indexers:");
            Console.WriteLine(fruit[0]);
            Console.WriteLine(fruit[1]);
            Console.WriteLine(fruit[2]);
            Console.WriteLine(fruit[3]);

            Console.WriteLine("print using loop:");
            foreach (string i in fruit)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
    }
}
