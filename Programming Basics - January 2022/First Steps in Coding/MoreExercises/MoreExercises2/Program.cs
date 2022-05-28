using System;

namespace MoreExercises2
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double area = (a * h) / 2;
            string final = area.ToString("0.00");

            Console.WriteLine(final);
        }
    }
}
