using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    //Find Evens or Odds
    //You are given a lower and an upper bound for a range of integer numbers. Then a command specifies if you need to list all even or odd numbers in the given range.
    //Use Predicate<T>.
    //
    //Examples
    //Input     Output
    //1 10      1 3 5 7 9
    //odd
    //
    //Input     Output
    //20 30     20 22 24 26 28 30
    //even


    class Program
    {
        static void Main()
        {
            List<int> numbers = CreateArray(Console.ReadLine().Split());
            Predicate<int> condition = CreateCondition(Console.ReadLine());
            Console.WriteLine(String.Join(' ', numbers
                .Where(num => condition(num)).ToList()));
        }

        private static List<int> CreateArray(string[] input)
        {
            List<int> array = new List<int>();
            int arrayStart = int.Parse(input[0]);
            int arrayEnd = int.Parse(input[1]);

            for (int i = arrayStart; i <= arrayEnd; i++)
            {
                array.Add(i);
            }

            return array;
        }

        private static Predicate<int> CreateCondition(string input)
        {
            switch (input)
            {
                case "odd":
                    return num => num % 2 != 0;
                case "even":
                    return num => num % 2 == 0;
                default:
                    throw new NotImplementedException();
            }          
        }
    }
}
