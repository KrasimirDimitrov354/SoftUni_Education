using System;
using System.Linq;

namespace ConsoleApp4
{
    //Add VAT
    //Create a program that reads one line of double prices separated by ", ". Print the prices with added VAT for all of them.
    //Format them to 2 signs after the decimal point. The order of the prices must be the same.
    //
    //VAT is equal to 20% of the price.
    //
    //Examples
    //Input             Output      Input           Output
    //1.38, 2.56, 4.4   1.66        1, 3, 5, 7      1.20
    //                  3.07                        3.60
    //                  5.28                        6.00
    //                                              8.40

    class Program
    {
        static void Main()
        {
            Func<double, double> addVAT = n => n + n * 0.2;
            Action<double> printPrice = p => Console.WriteLine($"{p:f2}");

            double[] prices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(n => double.Parse(n))
                .Select(n => addVAT(n))
                .ToArray();

            foreach (double price in prices)
            {
                printPrice(price);
            }
        }
    }
}
