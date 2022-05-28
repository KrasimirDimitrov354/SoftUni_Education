using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            double count = int.Parse(Console.ReadLine());
            double priceEntry = double.Parse(Console.ReadLine());
            double priceLounge = double.Parse(Console.ReadLine());
            double priceUmbrela = double.Parse(Console.ReadLine());

            double priceTotal = (count * priceEntry) + ((Math.Ceiling(count * 0.75)) * priceLounge) + ((Math.Ceiling(count / 2)) * priceUmbrela);

            Console.WriteLine($"{priceTotal:f2} lv.");
        }
    }
}
