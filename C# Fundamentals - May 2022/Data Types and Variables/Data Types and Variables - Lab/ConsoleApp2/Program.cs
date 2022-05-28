using System;

namespace ConsoleApp2
{
    class Program
    {
    //2.    Pounds to Dollars
    //Create a program that converts British pounds to US dollars formatted to the 3rd decimal point.
    //1 British Pound = 1.31 Dollars
    //Examples
    //Input Output
    //80	104.800
    //39	51.090

        static void Main()
        {
            float pounds = float.Parse(Console.ReadLine());

            float dollars = pounds * 1.31f;

            Console.WriteLine($"{dollars:f3}");
        }
    }
}
