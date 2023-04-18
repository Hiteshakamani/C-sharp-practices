using System;

namespace nullable_operator
{
    class Person {
        int? Id { get; set; }
        string Name { get; set; }
        int? Age { get; set; }
        static void Main(string[] args)
        {
            List<Person> people = new List<Person> {
            new Person { Id = 1 ,Name = "abc",Age =25},
            new Person { Id = 2 ,Name = "def", Age = null },
            new Person { Id = 3 ,Name = null, Age=50}
  
            };
            foreach (var person in people)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Age: {person.Age}");

            }

            Console.WriteLine("After nullable operator");
            people[1].Id = null;
            people[1].Age = null;

            foreach (var person in people){
                person.Id ??= 0;
                person.Name ??= "unknon";
                Console.WriteLine($"Id : {person.Id}, Name: {person.Name} , Age: {person.Age?.ToString() ?? "not given"}");
            }

        }

        }

    }

