using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Structs
{
    //this code is the practice of the topic of difference between struct and class

    public struct person          //value type :stored on the stack
    {
        public string name;
        public int age;
        public string gender;

        public person(string Name, int Age, string Gender)
        {
            name = Name;
            age = Age;
            gender = Gender;
        }

        public void person_info()
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Age : {age}");
            Console.WriteLine($"Gender : {gender}");
        }
    }


    public class company        //reference type :  stored on the heap
    {
        public string name;
        public string address;
        public double year;

        public company(string Name, string Address, double Year)
        {
            name = Name;
            address = Address;
            year = Year;
        }

        public void company_info()
        {
            Console.WriteLine($"Name : {name}");
            Console.WriteLine($"Address : {address}");
            Console.WriteLine($"Year : {year}");
        }
    }
    internal class Program
    {
            static void Main(string[] args)
            {
            person p1 = new person("abc",23,"Female");

            company c1 = new company("cybercom", "Ahmedabad", 12);

            p1.person_info();

            c1.company_info();


            p1.name = "def";
            p1.gender = "Male";
            p1.age = 30;

            c1.name = "abc";
            c1.address = "Baroda";
            c1.year = 30;

            p1.person_info();

            c1.company_info();
            Console.ReadKey();
        }
    }
}
