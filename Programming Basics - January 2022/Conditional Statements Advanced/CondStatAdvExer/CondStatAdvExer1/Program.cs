using System;

namespace CondStatAdvExer1
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfMovie = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double income = 0;

            switch (typeOfMovie)
            {
                case "Premiere":
                    income = rows * columns * 12;
                    break;
                case "Normal":
                    income = rows * columns * 7.5;
                    break;
                case "Discount":
                    income = rows * columns * 5;
                    break;
            }

            Console.WriteLine($"{income:f2} leva");
        }
    }
}
