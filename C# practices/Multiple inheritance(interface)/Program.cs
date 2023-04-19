using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_inheritance_interface_
{
    public interface ITeacher
    {
        string Name { get; set; }
        int Age { get; set; }

        void TeacherInfo();
    }
    public interface IStudent
    {
        string Name { get; set; }
        int Age { get; set; }

        void StudentInfo();
    }

    public class person : IStudent, ITeacher
    {
        private string name;
        private int age;

        string ITeacher.Name
        {
            get { return name; }
            set { name = value; }
        }
        int ITeacher.Age
        {
            get { return age; }
            set { age = value; }
        }

        string IStudent.Name
        {
            get { return name; }
            set { name = value; }
        }
        int IStudent.Age
        {
            get { return age; }
            set { age = value; }
        }

        void IStudent.StudentInfo()
        {
            Console.WriteLine($"Student : {name} is {age} years old ");
        }
        void ITeacher.TeacherInfo()
        {
            Console.WriteLine($"Teacher : {name} is {age} years old ");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            person p1 = new person();
            ((ITeacher)p1).Name = "abc";
            ((ITeacher)p1).Age = 30;
            ((IStudent)p1).Name = "def";
            ((IStudent)p1).Age = 12;
            ((ITeacher) p1).TeacherInfo();
            ((IStudent)p1).StudentInfo();
            Console.ReadKey();
        }
    }
}
