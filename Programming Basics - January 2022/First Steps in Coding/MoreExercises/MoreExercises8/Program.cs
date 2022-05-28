using System;

namespace MoreExercises8
{
    class Program
    {
        static void Main(string[] args)
        {
            double r = double.Parse(Console.ReadLine());
            double pi = Math.PI;

            double area = (r * r) * pi;
            double perimeter = (pi * r) * 2;

            Console.WriteLine(area.ToString("0.00"));
            Console.WriteLine(perimeter.ToString("0.00"));
        }
    }
}
