using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7
{
    //List of Predicates
    //Find all numbers in the range 1...N that is divisible by the numbers of a given sequence.
    //
    //On the first line you will be given an integer N – which is the end of the range.
    //On the second line you will be given a sequence of integers which are the dividers.
    //
    //Examples
    //Input         Output
    //10            2 4 6 8 10
    //1 1 1 2
    //
    //Input         Output
    //100           20 40 60 80 100
    //2 5 10 20

    class Program
    {
        static void Main()
        {
            List<int> numbers = FillList(int.Parse(Console.ReadLine()));
            List<int> dividers = Console.ReadLine()
                .Split()
                .Select(d => int.Parse(d))
                .ToList();

            ValidateAndPrint(numbers, dividers);
        }

        private static List<int> FillList(int collectionEnd)
        {
            List<int> numbers = new List<int>();

            for (int i = 1; i <= collectionEnd; i++)
            {
                numbers.Add(i);
            }

            return numbers;
        }

        private static void ValidateAndPrint(List<int> numbers, List<int> dividers)
        {
            Func<int, int, bool> numberValidator = (number, divider) => number % divider == 0;

            for (int i = 0; i < dividers.Count; i++)
            {
                numbers = numbers
                    .Where(num => numberValidator(num, dividers[i]))
                    .ToList();
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
