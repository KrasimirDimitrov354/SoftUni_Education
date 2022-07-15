using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    //Count Chars in a String
    //Create a program that counts all characters in a string, except for space(' '). 
    //Print all the occurrences in the following format:
    //  "{char} -> {occurrences}"
    //Examples
    //Input             Output
    //text              t -> 2
    //                  e -> 1
    //                  x -> 1
    //
    //Input             Output
    //text text text    t -> 6
    //                  e -> 3
    //                  x -> 3

    class Program
    {
        static void Main()
        {
            char[] input = Console.ReadLine()
                .Where(c => c != ' ')
                .ToArray();

            Dictionary<char, int> countOfChars = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (countOfChars.ContainsKey(currentChar) == false)
                {
                    countOfChars.Add(currentChar, 0);
                }

                countOfChars[currentChar]++;
            }

            foreach (var character in countOfChars)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
