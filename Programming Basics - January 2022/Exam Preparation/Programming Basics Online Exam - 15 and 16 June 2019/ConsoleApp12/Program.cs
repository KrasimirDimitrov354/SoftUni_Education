using System;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {
            string movieName = Console.ReadLine();
            int days = int.Parse(Console.ReadLine());
            int ticketsCount = int.Parse(Console.ReadLine());
            double ticketPrice = double.Parse(Console.ReadLine());
            int percentage = int.Parse(Console.ReadLine());

            double total = (ticketsCount * ticketPrice) * days;
            total -= total * (percentage / 100.0);

            Console.WriteLine($"The profit from the movie {movieName} is {total:f2} lv.");
        }
    }
}
