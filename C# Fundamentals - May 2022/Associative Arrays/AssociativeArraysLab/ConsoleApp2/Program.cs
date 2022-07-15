using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    //Odd Occurrences
    //Create a program that extracts all elements from a given sequence of words that are present in it an odd number of times (case-insensitive).
    //  •	Words are given on a single line, space-separated.
    //  •	Print the result elements in lowercase, in their order of appearance.
    //Examples
    //Input                             Output
    //Java C# PHP PHP JAVA C java	    java c# c
    //3 5 5 hi pi HO Hi 5 ho 3 hi pi	5 hi
    //a a A SQL xx a xx a A a XX c      a sql xx c

    class Program
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Dictionary<string, int> occurencesOfWords = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i].ToLower();

                if (occurencesOfWords.ContainsKey(currentWord))
                {
                    occurencesOfWords[currentWord]++;
                }
                else
                {
                    occurencesOfWords.Add(currentWord, 1);
                }
            }

            List<string> oddWords = new List<string>();

            foreach (var occurence in occurencesOfWords)
            {
                if (occurence.Value % 2 != 0)
                {
                    oddWords.Add(occurence.Key);
                }
            }

            Console.WriteLine(string.Join(' ', oddWords));
        }
    }
}
