using System;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int totalFood = int.Parse(Console.ReadLine());
            double dogFood = double.Parse(Console.ReadLine());
            double catFood = double.Parse(Console.ReadLine());
            double turleFood = double.Parse(Console.ReadLine());

            double foodEaten = (days * dogFood) + (days * catFood) + (days * (turleFood / 1000));

            if (totalFood >= foodEaten)
            {
                Console.WriteLine($"{Math.Floor(totalFood - foodEaten)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(foodEaten - totalFood)} more kilos of food are needed.");
            }
        }
    }
}
