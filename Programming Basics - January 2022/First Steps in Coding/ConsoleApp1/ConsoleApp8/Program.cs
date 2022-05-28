using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogFoodNumber = int.Parse(Console.ReadLine());
            int catFoodNumber = int.Parse(Console.ReadLine());

            double dogFoodPrice = 2.5;
            int catFoodPrice = 4;

            double total = (dogFoodNumber * dogFoodPrice) +
                (catFoodNumber * catFoodPrice);

            Console.WriteLine($"{total} lv.");

        }
    }
}
