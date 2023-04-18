
using System;

public class Employee {
    public string FirstName;
    public string LastName;

    public void printFullName()
    {
        Console.WriteLine(FirstName+ " "+LastName);

    }
}

public class ParttimeEmployee : Employee { 
    public new void printFullName()
    {
        Console.WriteLine(FirstName + " "+LastName + " abc");
    }

}

public class FulltimeEmployee : Employee
{
    public new void printFullName()
    {
        Console.WriteLine(FirstName + " " + LastName + " def");
    }

}

public class Final
{
    public static void Main(string[] args)
    {
        Employee emp = new Employee();
        emp.FirstName = "Employee";
        emp.LastName = "Name";
        emp.printFullName();


        FulltimeEmployee emp1 = new FulltimeEmployee();
        emp1.FirstName = "Fulltime";
        emp1.LastName  = "Employee";
        emp1.printFullName();

        ParttimeEmployee emp2 = new ParttimeEmployee();
        emp2.FirstName = "Fulltime";
        emp2.LastName = "Employee";
        emp2.printFullName();
    }
}
