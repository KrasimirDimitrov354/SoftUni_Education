using System;

namespace ConsoleApp1
{
    //Knights of Honor
    //Create a program that reads a collection of strings from the console, appends "Sir" in front of every name and then prints them onto the console.
    //Each name should be printed on a new line. Use Action<T>.
    //
    //Examples
    //Input
    //  Lucas Noah Tea
    //Output
    //  Sir Lucas
    //  Sir Noah
    //  Sir Tea
    //
    //Input
    //  Teo Lucas Harry
    //Output
    //  Sir Teo
    //  Sir Lucas
    //  Sir Harry

    class Program
    {
        static void Main()
        {
            string[] names = Console.ReadLine().Split();
            Action<string> printName = name => Console.WriteLine($"Sir {name}");

            foreach (string name in names)
            {
                printName(name);
            }
        }
    }
}
