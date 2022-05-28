using System;

namespace ConsoleAppExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPages = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            double hoursPerDay = (totalPages / pagesPerHour) / days;

            Console.WriteLine(hoursPerDay);
        }
    }
}
