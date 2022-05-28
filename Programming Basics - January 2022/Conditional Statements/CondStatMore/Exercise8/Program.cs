using System;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            string fuel = Console.ReadLine();
            int litres = int.Parse(Console.ReadLine());

            if ((fuel == "Diesel") || (fuel == "Gasoline") || (fuel == "Gas"))
            {
                if (litres >= 25)
                {
                    Console.WriteLine($"You have enough {fuel.ToLower()}.");
                }
                else
                {
                    Console.WriteLine($"Fill your tank with {fuel.ToLower()}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid fuel!");
            }
        }
    }
}
