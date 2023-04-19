using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__practices
{

    public class customer
    {
        private int age;
        private string name;
        private string mobile_number;

        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 18)
                {
                    throw new ArgumentException("Age must be above 18 OR 18.");
                }
                age = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentException("Name can't be null or empty");
                }
            }
        }
        public string Mobile_number
        {
            get { return mobile_number; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length == 10 && value.All(char.IsDigit))
                {
                    mobile_number = value;
                }
                else
                {
                    throw new ArgumentException("Mobile number shouldn't be null and must have 10 digits.");
                }
            }
        }



        internal class Program
        {
            static void Main(string[] args)
            {
                customer c1 = new customer();
                try
                {
                    Console.WriteLine("Enter name :");
                    c1.Name = Console.ReadLine();

                    Console.WriteLine("Enter age :");
                    c1.Age = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter number :");
                    c1.Mobile_number = Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"Name: {c1.Name}");
                Console.WriteLine($"Age: {c1.Age}");
                Console.WriteLine($"Number : {c1.mobile_number}");
                Console.ReadKey();

            }
        }
    }
}
