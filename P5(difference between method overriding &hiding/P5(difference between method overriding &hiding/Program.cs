using System;

public class baseClass
{
    public virtual void first_method()
    {
        Console.WriteLine("This method can be override....");
    } 
    public static void second_method()
    {
        Console.WriteLine("This is the static method...");
    }
}

public class derivedClass : baseClass 
{
    public override void first_method()
    {
        Console.WriteLine("The first_method is changed....");
    }

    public new static void second_method()
    {
        Console.WriteLine("The second_method is hide...");
    }
}

public class Program { 

    static void Main(string[] args)

    {
        baseClass b = new derivedClass();
        b.first_method(); //output will be The first_method is changed...
        baseClass.second_method();// output will be This is the static method...

        Console.WriteLine();

        derivedClass b2 = new derivedClass();
        b2.first_method(); //output :The first_method is changed....
        derivedClass.second_method(); // output : The second_method is hide...

        Console.WriteLine();

        derivedClass.second_method();// output : The second_method is hide...
    }
}