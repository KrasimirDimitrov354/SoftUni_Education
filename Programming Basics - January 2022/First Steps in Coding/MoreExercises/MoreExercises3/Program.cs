using System;

namespace MoreExercises3
{
    class Program
    {
        static void Main(string[] args)
        {
            double celsius = double.Parse(Console.ReadLine());

            double fahrenheit = (celsius * 1.8) + 32;
            string final = fahrenheit.ToString("0.00");

            Console.WriteLine(final);
        }
    }
}
