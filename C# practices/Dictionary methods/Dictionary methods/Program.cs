using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,string> keyValuePairs = new Dictionary<int,string>();

            keyValuePairs.Add(1, "Hitesha");
            keyValuePairs.Add(2, "Hitanshi");
            keyValuePairs.Add(3, "Hiren");
            keyValuePairs.Add(4, "Hardik");
            keyValuePairs.Add(5, "Harish");

            //containskey

            if (keyValuePairs.ContainsKey(2))
            {
                Console.WriteLine(keyValuePairs[2]);
            }
            else
            {
                Console.WriteLine("This key doesn't exists...!");
            }


            //containsvalue
            if(keyValuePairs.ContainsValue("Hardik"))
            {
                Console.WriteLine("Hardik exists!");
            }
            else
            {
                Console.WriteLine("Hardik doesn't exists !");
            }

            Console.WriteLine("The value for key 3 is: " + keyValuePairs[3]);

            // Update the value for a key 
            keyValuePairs[4] = "durian";

            // Remove a key-value pair 
            keyValuePairs.Remove(5);

            // Print all the keys
            Console.WriteLine("All the keys in the dictionary:");
            foreach (int key in keyValuePairs.Keys)
            {
                Console.WriteLine(key);
            }

            // Print all the values 
            Console.WriteLine("All the values in the dictionary:");
            foreach (string value in keyValuePairs.Values)
            {
                Console.WriteLine(value);
            }

            // Clear 
            keyValuePairs.Clear();
            Console.WriteLine("The dictionary has been cleared");

            Console.ReadLine();



        }
    }
}
