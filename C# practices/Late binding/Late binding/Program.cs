using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Late_binding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type classType = assembly.GetType("Late_binding.Person");

            object obj = Activator.CreateInstance(classType);

            MethodInfo method = classType.GetMethod("MyMethod");
            object[] parameters = new object[] { "John" };
            method.Invoke(obj, parameters);

            PropertyInfo property = classType.GetProperty("MyProperty");
            object value = property.GetValue(obj);
            Console.WriteLine("MyProperty = " + value);

            Console.ReadKey();
        }
    }
}
