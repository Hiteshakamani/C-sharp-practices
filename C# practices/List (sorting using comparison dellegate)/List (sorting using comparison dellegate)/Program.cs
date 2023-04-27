using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace List__sorting_using_comparison_dellegate_
{
    public class Intern : IComparable<Intern>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Intern(string firstname , string lastname ,int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public int CompareTo(Intern other)
        {
            // Compare by age first
            int result = Age.CompareTo(other.Age);

            // If ages are equal, compare by name
            if (result == 0)
            {
                result = Firstname.CompareTo(other.Firstname);
            }

            return result;
        }
        public override string ToString()
        {
            return $"{Firstname} {Lastname} , {Age} years old";
        }
    }

    internal class Program
    {
        static void PrintList(List<Intern> list)
        {
            foreach (Intern i in list)
            {
                Console.WriteLine(i);
            }
        }
        static void Main(string[] args)
        {
            List<Intern> interns = new List<Intern>
            {
            new Intern("Hitesha" ,"kamani",21),
            new Intern("Hiren", "khunt", 21),
            new Intern("Hitanshi", "shah", 20)
            };

            Console.WriteLine("Interns List :");
           PrintList(interns);

            interns.Sort();

            Console.WriteLine("Sorted List (Asc) :");
            PrintList(interns);

            Console.ReadKey();
        }
    }
}
