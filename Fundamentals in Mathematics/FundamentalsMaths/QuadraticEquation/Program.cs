using System;

namespace QuadraticEquation
{
    //Valid quadratic equation: a(x * x) + bx + c;
    //  - highest power must be 2.
    //  - a must be different than 0.

    class Program
    {
        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double discriminant = Math.Pow(b, 2) - (4 * a * c);

            if (discriminant < 0)
            {
                Console.WriteLine("No real roots");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"One real root: x = {x}");
            }
            else
            {
                double x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine($"Two real roots: x1 = {x1}, x2 = {x2}");
            }
        }
    }
}
