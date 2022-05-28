using System;

namespace ConsoleAppExercises9
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double occupiedSpace = double.Parse(Console.ReadLine());

            double totalSpaceDCM = length * width * height;
            double totalSpaceLTR = totalSpaceDCM / 1000;

            double occupiedSpacePercentage = occupiedSpace / 100;

            double final = totalSpaceLTR * (1 - occupiedSpacePercentage);

            Console.WriteLine(final);
        }
    }
}
