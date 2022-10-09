using System;
using System.Linq;

namespace ConsoleApp6
{
    //Predicate for Names
    //Write a program that filters a list of names according to their length.
    //
    //On the first line you will be given an integer n, representing a name's length.
    //On the second line you will be given some names as strings separated by space.
    //
    //Write a function that prints only the names whose length is less than or equal to n.
    //
    //Examples
    //Input
    //  4
    //  Karl Anna Kris Yahto
    //Output
    //  Karl
    //  Anna
    //  Kris
    //
    //Input
    //  4
    //  Karl James George Robert Patricia
    //Output
    //  Karl

    class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());

            Predicate<int> checkLength = n => n <= length;
            Action<string[]> printAll = output => Console.Write(String.Join('\n', output));

            printAll(Console.ReadLine()
                .Split(' ')
                .Where(name => checkLength(name.Length))
                .ToArray());
        }
    }
}
