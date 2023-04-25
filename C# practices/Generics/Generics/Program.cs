using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    //Generic class
    class Class1<T>
    {
        private List<T> list = new List<T>();
        public void add(T item)
        {
            list.Add(item);
        }
        public void remove(T item)
        {
            list.Remove(item);
        }
        public void display()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }
    }


    public class ClassWithConstraint<T> where T : struct
    {
        private List<T> list = new List<T>();

        public void add(T item)
        {
            list.Add(item);
        }

        public void display()
        {
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
    internal class Program
    {
        //Generic method
        public static bool Equal<T>(T a, T b){
            return a.Equals(b);
        }
        static void Main(string[] args)
        {
            bool Equal = Program.Equal<int>(1, 2);
            if (Equal)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }

            Class1<string> a = new Class1<string>();
            a.add("a");
            a.add("b");
            a.add("c");
            a.add("d");
            a.remove("b");
            a.remove("c");
            a.display();


            ClassWithConstraint<int> b = new ClassWithConstraint<int>();
            b.add(1);
            b.add(2);
            b.add(3);
            b.display();

            Console.ReadKey();

        }


    }
}
