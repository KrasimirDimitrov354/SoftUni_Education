using System;

namespace FundamentalsExer10
{
    class Program
    {
        static void Main()
        {
            int lostGames = int.Parse(Console.ReadLine());
            double priceHeadset = double.Parse(Console.ReadLine());
            double priceMouse = double.Parse(Console.ReadLine());
            double priceKeyboard = double.Parse(Console.ReadLine());
            double priceDisplay = double.Parse(Console.ReadLine());

            double expenses = 0.0;
            int counter = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    expenses += priceHeadset;
                }

                if (i % 3 == 0)
                {
                    expenses += priceMouse;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    expenses += priceKeyboard;
                    counter++;

                    if (counter == 2)
                    {
                        expenses += priceDisplay;
                        counter = 0;
                    }
                }
            }

            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }
    }
}
