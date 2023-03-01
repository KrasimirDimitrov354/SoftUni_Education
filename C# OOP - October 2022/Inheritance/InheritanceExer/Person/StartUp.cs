using System;

namespace Person
{
    //Person
    //Model an application for storing data about people. You should be able to have a person and a child. The child derives from the person.
    //
    //The only constraints are:
    //  -	People should not be able to have a negative age.
    //  -	Children should not be able to have an age greater than 15.
    //
    //Input
    //  •	On the first line you will receive a string Name.
    //  •	On the second line you will receive an integer Age.
    //Output
    //  •	Override the ToString() method to display the following: "Name: {Name}, Age: {Age}".

    public class StartUp
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            Child child = new Child(name, age);
            Console.WriteLine(child);
        }
    }
}