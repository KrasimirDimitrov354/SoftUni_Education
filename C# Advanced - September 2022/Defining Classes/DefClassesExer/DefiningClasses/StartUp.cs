using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    //Define a class Person and class Family
    //Define a class Person with private fields for name and age and public properties Name and Age. Use both the inline initialization and the default constructor.
    //
    //Add 3 constructors to the Person class.
    //  •	The first should take no arguments and produce a person with the name "No name" and age = 1.
    //  •	The second should accept only an integer number for the age and produce a person with the name "No name" and age equal to the passed parameter.
    //  •	The third one should accept a string for the name and an integer for the age and should produce a person with the given name and age.
    //Use constructor chaining.
    //
    //Create a class Family by using the class Person. The class Family should have:
    //  - a list of people;
    //  - a method for adding members - void AddMember(Person member);
    //  - a method returning the oldest family member – Person GetOldestMember().
    //
    //Write a program that reads the names and ages of N people and adds them to the family. Then print the name and age of the oldest member.
    //Examples
    //Input     Output
    //3         Annie 5
    //Peter 3
    //George 4
    //Annie 5
    //
    //Using the Person class, write a program that reads from the console N lines of personal information.
    //Print all people whose age is more than 30 years, sorted in alphabetical order.
    //Examples
    //Input     Output
    //5         Lily - 44
    //Niki 33   Niki - 33
    //Yord 88   Yord - 88
    //Teo 22
    //Lily 44
    //Stan 11

    public class StartUp
    {
        static void Main()
        {
            Family family = GetFamily();
            List<Person> sortedFamily = family.SortFamily();

            foreach (Person person in sortedFamily)
            {
                person.Speak();
            }
        }

        private static Family GetFamily()
        {
            Family family = new Family();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(info[0], int.Parse(info[1]));
                family.AddMember(person);
            }

            return family;
        }
    }
}
