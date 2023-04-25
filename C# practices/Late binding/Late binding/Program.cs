using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Late_binding
{
    public class Person
    {

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type personType = assembly.GetType("Late_binding.Person");

            object obj = Activator.CreateInstance(personType);

            MethodInfo method = personType.GetMethod("Details");
            object[] parameters = new object[] { "Abc" };
            method.Invoke(obj, parameters);

            PropertyInfo property = personType.GetProperty("MyProperty");
            object value = property.GetValue(obj);
            Console.WriteLine("MyProperty = " + value);

            Console.ReadKey();
        }
    }
}
