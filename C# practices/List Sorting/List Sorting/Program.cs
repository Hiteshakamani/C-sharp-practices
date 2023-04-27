using System;
using System.Collections.Generic;

namespace List_Sorting
{
    public class Interns
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Interns(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age} years old";
        }
    }

    internal class Program
    {
        static void PrintList(List<Interns> list)
        {
            foreach (Interns i in list)
            {
                Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            List<Interns> interns = new List<Interns>
            {
                new Interns("Hitesha", "kamani", 21),
                new Interns("Hiiren", "khunt", 21),
                new Interns("Hitanshi", "Shah", 20)
            };

            Console.WriteLine("List before sorting:");
            PrintList(interns);

            // Sort by age ascending
            interns.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));

            Console.WriteLine("\nList after sorting by age:");
            PrintList(interns);

            // Sort by last name descending
            interns.Sort((p1, p2) => p2.LastName.CompareTo(p1.LastName));

            Console.WriteLine("\nList after sorting by last name:");
            PrintList(interns);

            Console.ReadKey();
        }
    }
}
