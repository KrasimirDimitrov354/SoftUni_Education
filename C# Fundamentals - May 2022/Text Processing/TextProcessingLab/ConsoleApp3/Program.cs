using System;

namespace ConsoleApp3
{
    //Substring
    //On the first line you will receive a string. On the second line you will receive a second string.
    //Create a program that removes all of the occurrences of the first string in the second until there is no match.
    //At the end print the remaining string.
    //Examples
    //Input         Output      Comment
    //ice           kgb         We remove ice once and we get "kgiciceeb"
    //kicegiciceeb              We match "ice" one more time and we get "kgiceb"
    //                          There is one more match.The finam result is "kgb"
    //
    //Input                     Output
    //hep                       SoftuniIsGreat
    //ShepoftunihepIsGrhepeat

    class Program
    {
        static void Main()
        {
            string stringToRemove = Console.ReadLine();
            string stringToRemoveFrom = Console.ReadLine();

            while (stringToRemoveFrom.Contains(stringToRemove))
            {
                stringToRemoveFrom = stringToRemoveFrom.Replace(stringToRemove, "");
            }

            Console.WriteLine(stringToRemoveFrom);
        }
    }
}
