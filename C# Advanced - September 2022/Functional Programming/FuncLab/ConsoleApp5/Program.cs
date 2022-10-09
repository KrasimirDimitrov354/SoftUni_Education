using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp5
{
    //Filter by Age
    //Write a program that receives an integer N on the first line. On the next N lines, read pairs of "[name], [age]".
    //
    //Then, you will read three lines:
    //  •	Condition - "younger" or "older"
    //  •	Age - Integer
    //  •	Format - "name", "age" or "name age"
    //Depending on the condition, print the correct pairs in the correct format.
    //Don’t use the built-in functionality from .NET. Create your methods.
    //
    //Examples
    //Input         Output
    //5             Lucas - 20
    //Lucas, 20     Mia - 29
    //Tomas, 18     Noah - 31
    //Mia, 29
    //Noah, 31
    //Simo, 16
    //older
    //20
    //name age    
    //
    //Input         Output
    //5             Tomas
    //Lucas, 20     Simo
    //Tomas, 18
    //Mia, 29
    //Noah, 31
    //Simo, 16
    //younger
    //20
    //name
    //
    //Input         Output
    //5             20
    //Lucas, 20     18
    //Tomas, 18     29
    //Mia, 29       31
    //Noah, 31      16
    //Simo, 16
    //younger
    //50
    //age


    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = CreatePeople(n);
            Condition condition = CreateCondition();

            Predicate<int> filter = CreateFilter(condition.Bracket, condition.Boundary);

            List<Person> filteredPeople = people
                .Where(p => filter(p.Age))
                .ToList();

            Action<List<Person>> print = CreateFormat(condition.Format);
            print(filteredPeople);
        }


        private static List<Person> CreatePeople(int peopleCount)
        {
            List<Person> people = new List<Person>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] personData = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                people.Add(new Person(personData[0], int.Parse(personData[1])));
            }

            return people;
        }

        private static Condition CreateCondition()
        {
            Condition condition = new Condition();
            condition.Bracket = Console.ReadLine();
            condition.Boundary = int.Parse(Console.ReadLine());
            condition.Format = Console.ReadLine();

            return condition;
        }

        private static Predicate<int> CreateFilter(string bracket, int boundary)
        {
            switch (bracket)
            {
                case "younger":
                    return f => f < boundary;
                case "older":
                    return f => f >= boundary;
            }

            throw new NotImplementedException();
        }

        private static Action<List<Person>> CreateFormat(string format)
        {
            switch (format)
            {
                case "name":
                    return output => Console.Write(String.Join('\n',
                        output
                        .Select(person => person.Name)
                        .ToArray()));
                case "age":
                    return output => Console.Write(String.Join('\n',
                        output
                        .Select(person => person.Age)
                        .ToArray()));
                default:
                    return output => PrintAll(output);
            }
        }

        private static void PrintAll(List<Person> people)
        {
            StringBuilder output = new StringBuilder();

            foreach (Person person in people)
            {
                output.AppendLine($"{person.Name} - {person.Age}");
            }

            Console.WriteLine(output);
        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Condition
    {
        public string Bracket { get; set; }
        public int Boundary { get; set; }
        public string Format { get; set; }
    }
}
