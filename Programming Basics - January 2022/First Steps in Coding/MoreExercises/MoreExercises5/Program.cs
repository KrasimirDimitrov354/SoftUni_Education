using System;

namespace MoreExercises5
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double lengthToCM = length * 100;
            double widthToCM = (width * 100) - 100;

            double seatsPerRow = Math.Floor(widthToCM / 70);
            double numberOfRows = Math.Floor(lengthToCM / 120);

            double final = (seatsPerRow * numberOfRows) - 3;

            Console.WriteLine(final);
        }
    }
}
