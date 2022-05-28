using System;

namespace ConsoleAppExercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            double chicken = double.Parse(Console.ReadLine());
            double fish = double.Parse(Console.ReadLine());
            double vegetable = double.Parse(Console.ReadLine());

            double chickenPrice = 10.35;
            double fishPrice = 12.40;
            double vegetablePrice = 8.15;

            double foodPrice = (chicken * chickenPrice) + (fish * fishPrice) +
                (vegetable * vegetablePrice);
            double dessert = foodPrice * 0.20;

            double total = foodPrice + dessert + 2.5;

            Console.WriteLine(total);
        }
    }
}
