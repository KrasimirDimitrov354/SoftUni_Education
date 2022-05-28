using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int group = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int cards = int.Parse(Console.ReadLine());
            int tickets = int.Parse(Console.ReadLine());

            double total = 0;

            total = nights * 20;
            total += cards * 1.6;
            total += tickets * 6;
            total *= group;
            total += total / 4;

            Console.WriteLine($"{total:f2}");
        }
    }
}
