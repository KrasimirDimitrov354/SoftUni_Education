using System;

namespace MoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            double b1 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double trapezoid = ((b1 + b2) * h) / 2;
            string final = trapezoid.ToString("0.00");

            Console.WriteLine(final);
        }
    }
}
