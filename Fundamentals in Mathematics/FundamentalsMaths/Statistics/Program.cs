using System;
using System.Linq;

namespace Statistics
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter data set:");
            double[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(n => double.Parse(n))
                .OrderBy(n => n)
                .ToArray();

            Console.WriteLine($"Mode: {GetMode(numbers)}");
            Console.WriteLine($"Mean: {Math.Round(numbers.Average(), 2)}");
            Console.WriteLine($"Median: {GetMedian(numbers)}");
        }

        private static double GetMode(double[] numbers)
        {
            var occurencesOfNumbers = numbers.ToLookup(num => num);
            int maxOccurences = occurencesOfNumbers.Max(num => num.Count());

            return occurencesOfNumbers
                .Where(num => num.Count() == maxOccurences)
                .Select(x => x.Key)
                .First();
        }

        private static double GetMedian(double[] numbers)
        {
            if (numbers.Length % 2 != 0)
            {
                return numbers.ElementAt(numbers.Length / 2);
            }
            else
            {
                return (numbers.ElementAt(numbers.Length / 2) 
                    + numbers.ElementAt((numbers.Length / 2) - 1)) / 2;
            }
        }
    }
}
