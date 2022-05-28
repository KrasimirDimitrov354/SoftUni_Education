using System;

namespace ConsoleAppExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            double rad = double.Parse(Console.ReadLine());

            double degree = (rad * 180) / Math.PI;

            Console.WriteLine(degree);
        }
    }
}
