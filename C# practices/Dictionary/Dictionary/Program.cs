using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public class employee
    {
        public string name { get; set; }
        public int id { get; set; }
        public string department { get; set; }  
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, employee> employee = new Dictionary<int, employee>();
            employee.Add(1, new employee { name = "Hitesha", id = 1, department = "HR" });
            employee.Add(2, new employee { name = "Hitanshi", id = 2, department = "HR" });
            employee.Add(3, new employee { name = "Hiren", id = 3, department = "HR" });

            Console.WriteLine("employee with key 1:");
            Console.WriteLine("Name: " + employee[1].name);
            Console.WriteLine("Id: " + employee[1].id);
            Console.WriteLine("Department: " + employee[1].department);
        
            if (employee.ContainsKey(2)) 
            {
                Console.WriteLine("employe with key 2 exists");
            }

            Console.WriteLine("All the key in dictionary......");

            foreach (int key in employee.Keys)
            {
                Console.WriteLine(key);

            }

            Console.WriteLine("All the value in dictionary......");
            foreach (employee value in employee.Values)
            {
                Console.WriteLine("Name: " + value.name);
                Console.WriteLine("Id: " + value.id);
                Console.WriteLine("Department: " + value.department);

            }
            employee.Remove(3);
            Console.WriteLine("Number of items in the dictionary: " + employee.Count);
            employee.Clear();
            Console.WriteLine("Number of items in the dictionary after clearing: " + employee.Count);
            Console.ReadKey();


        }
    }
}
