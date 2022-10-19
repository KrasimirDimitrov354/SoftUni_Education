using System;
using System.Linq;

namespace Froggy
{
    //Froggy
    //You have a tiny little Frog and a Lake that has a path of stones in it. Every stone has a number.
    //Our frog must cross the lake along that path and then return, but there are some rules.
    //
    //First the frog must jump on all the stones which are in even positions in ascending order.
    //Then on all the odd ones, but in reversed order.
    //
    //The order of the stones and their numbers will be given on the first line of input.
    //You must print the order of stones in which our frog jumped from one to another.
    //
    //Try to achieve this functionality by creating a class Lake that will hold all stone numbers in their order of input.
    //Have it implement the IEnumerable<int> interface with custom GetEnumerator() method.
    //
    //Examples
    //Input                     Output
    //1, 2, 3, 4, 5, 6, 7, 8    1, 3, 5, 7, 8, 6, 4, 2
    //
    //Input                     Output
    //1, 2, 3, 4, 5             1, 3, 5, 4, 2
    //
    //Input                     Output
    //13, 23, 1, -8, 4, 9       13, 1, 4, 9, -8, 23

    class Program
    {
        static void Main()
        {
            Lake stonesInLake = GetStones();
            Frog frog = GetFrog(stonesInLake);
            frog.ShowPath();
        }

        private static Lake GetStones()
        {
            return new Lake(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(s => int.Parse(s))
                .ToArray());
        }

        private static Frog GetFrog(Lake stonesInLake)
        {
            return new Frog(String.Join(", ", stonesInLake));
        }
    }
}
