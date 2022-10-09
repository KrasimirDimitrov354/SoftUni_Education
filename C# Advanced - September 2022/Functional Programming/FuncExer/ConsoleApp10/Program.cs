using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    //TriFunction
    //Create a program that traverses a collection of names and returns the first name whose sum of characters is equal to or larger than a given number N.
    //The number will be given on the first line.
    //
    //Use a function that accepts another function as one of its parameters. Start by building a regular function to hold the basic logic of the program.
    //Something similar to Func<string, int, bool>. Afterward, create your main function which should accept the first function as one of its parameters.
    //
    //Examples
    //Input                         Output
    //350                           Mary
    //Rob Mary Paisley Spencer
    //
    //Input                         Output
    //666                           William
    //Paul Thomas William

    class Program
    {
        static void Main()
        {
            int sum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Dictionary<string, int> valuesOfNames = CreateDictionary(names);
            Predicate<int> condition = sumOfChars => sumOfChars >= sum;

            Func<Dictionary<string, int>, string> findName = FindName(valuesOfNames, condition);
            Console.WriteLine(findName(valuesOfNames));
        }

        private static Dictionary<string, int> CreateDictionary(string[] names)
        {
            Dictionary<string, int> valuesOfNames = new Dictionary<string, int>();

            foreach (string name in names)
            {
                valuesOfNames.Add(name, FindValueOfName(name));
            }

            return valuesOfNames;
        }

        private static int FindValueOfName(string name)
        {
            int value = 0;

            for (int i = 0; i < name.Length; i++)
            {
                char letter = name[i];
                value += letter;
            }

            return value;
        }

        private static Func<Dictionary<string, int>, string> FindName(Dictionary<string, int> valuesOfNames, Predicate<int> condition)
        {
            foreach (var valueOfName in valuesOfNames)
            {
                if (condition(valueOfName.Value))
                {
                    return name => valueOfName.Key;
                }
            }

            return name => String.Empty;
        }
    }
}
