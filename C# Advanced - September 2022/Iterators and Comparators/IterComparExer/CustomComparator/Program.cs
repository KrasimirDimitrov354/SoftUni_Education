using System;
using System.Linq;

namespace CustomComparator
{
    //Custom Comparator
    //Write a custom comparator that sorts all even numbers before all the odd ones, in ascending order.
    //Pass it to Array.Sort() function and print the result.
    //
    //Examples
    //Input         Output
    //1 2 3 4 5 6   2 4 6 1 3 5
    //-3 2          2 -3

    class Program
    {
        static void Main()
        {
            Func<int, int, int> numberComparator = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }
                else if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                else
                {
                    return x.CompareTo(y);
                }
            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            Array.Sort(numbers, new Comparison<int>(numberComparator));

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
