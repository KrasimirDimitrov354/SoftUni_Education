using System;

namespace ConsoleApp22
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesPrice = double.Parse(Console.ReadLine());
            double bananasKilograms = double.Parse(Console.ReadLine());
            double orangesKilograms = double.Parse(Console.ReadLine());
            double raspberryKilograms = double.Parse(Console.ReadLine());
            double strawberriesKilograms = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberriesPrice / 2;
            double orangesPrice = raspberryPrice - (raspberryPrice * 0.4);
            double bananasPrice = raspberryPrice - (raspberryPrice * 0.8);

            double sum = (strawberriesPrice * strawberriesKilograms) + (bananasPrice * bananasKilograms) +
                (orangesPrice * orangesKilograms) + (raspberryPrice * raspberryKilograms);

            Console.WriteLine($"{sum:f2}");
        }
    }
}